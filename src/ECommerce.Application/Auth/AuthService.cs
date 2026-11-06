using ECommerce.Admin;
using ECommerce.Core.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ECommerce.Application.Auth;

public interface IAuthService
{
    Task<AuthResult<AuthTokens>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<AuthResult<AuthTokens>> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<AuthResult<bool>> ChangePasswordAsync(int adminId, ChangePasswordRequest request, CancellationToken cancellationToken = default);
    Task<AdminProfile?> GetProfileAsync(int adminId, CancellationToken cancellationToken = default);
}

public class AuthService(
    IRepository<DefAdmin> admins,
    IRepository<AdminRefreshToken> refreshTokens,
    IUnitOfWork unitOfWork,
    IPasswordHasher<DefAdmin> passwordHasher,
    ITokenService tokenService,
    IOptions<AuthOptions> options,
    TimeProvider clock) : IAuthService
{
    private readonly AuthOptions _options = options.Value;

    private DateTime Now => clock.GetUtcNow().UtcDateTime;

    public async Task<AuthResult<AuthTokens>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var admin = await admins.FirstOrDefaultAsync(a => a.UserName == request.UserName, cancellationToken);
        if (admin is null || !admin.IsActive)
            return AuthResult<AuthTokens>.Failure(AuthError.InvalidCredentials);

        var now = Now;
        if (admin.IsLockedOut(now))
            return AuthResult<AuthTokens>.Failure(AuthError.LockedOut);

        var verification = VerifyPassword(admin, request.Password);
        if (verification == PasswordVerificationResult.Failed)
        {
            admin.RegisterFailedLogin(now, _options.MaxFailedLoginAttempts, TimeSpan.FromMinutes(_options.LockoutMinutes));
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return AuthResult<AuthTokens>.Failure(admin.IsLockedOut(now) ? AuthError.LockedOut : AuthError.InvalidCredentials);
        }

        if (verification == PasswordVerificationResult.SuccessRehashNeeded)
            admin.PasswordHash = passwordHasher.HashPassword(admin, request.Password);

        admin.RegisterSuccessfulLogin(now);
        var tokens = IssueTokens(admin, now);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return AuthResult<AuthTokens>.Success(tokens);
    }

    public async Task<AuthResult<AuthTokens>> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var hash = tokenService.HashRefreshToken(refreshToken);
        var stored = await refreshTokens.FirstOrDefaultAsync(t => t.TokenHash == hash, cancellationToken);
        if (stored is null)
            return AuthResult<AuthTokens>.Failure(AuthError.InvalidRefreshToken);

        var now = Now;
        if (!stored.IsActive(now))
        {
            // Döndürülmüş bir token'ın tekrar kullanılması çalınma belirtisidir; tüm oturumlar kapatılır.
            if (stored.RevokedAt is not null)
            {
                await RevokeAllAsync(stored.AdminId, now, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return AuthResult<AuthTokens>.Failure(AuthError.InvalidRefreshToken);
        }

        var admin = await admins.GetByIdAsync(stored.AdminId, cancellationToken);
        if (admin is null || !admin.IsActive || admin.IsLockedOut(now))
        {
            stored.Revoke(now);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return AuthResult<AuthTokens>.Failure(AuthError.InvalidRefreshToken);
        }

        var tokens = IssueTokens(admin, now);
        stored.Revoke(now, tokenService.HashRefreshToken(tokens.RefreshToken));
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return AuthResult<AuthTokens>.Success(tokens);
    }

    public async Task LogoutAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var hash = tokenService.HashRefreshToken(refreshToken);
        var stored = await refreshTokens.FirstOrDefaultAsync(t => t.TokenHash == hash, cancellationToken);
        if (stored is null || stored.RevokedAt is not null)
            return;

        stored.Revoke(Now);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<AuthResult<bool>> ChangePasswordAsync(int adminId, ChangePasswordRequest request, CancellationToken cancellationToken = default)
    {
        var admin = await admins.GetByIdAsync(adminId, cancellationToken);
        if (admin is null)
            return AuthResult<bool>.Failure(AuthError.NotFound);

        if (VerifyPassword(admin, request.CurrentPassword) == PasswordVerificationResult.Failed)
            return AuthResult<bool>.Failure(AuthError.InvalidCredentials);

        admin.PasswordHash = passwordHasher.HashPassword(admin, request.NewPassword);
        await RevokeAllAsync(admin.Id, Now, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return AuthResult<bool>.Success(true);
    }

    public async Task<AdminProfile?> GetProfileAsync(int adminId, CancellationToken cancellationToken = default)
    {
        var admin = await admins.GetByIdAsync(adminId, cancellationToken);
        return admin is null
            ? null
            : new AdminProfile(admin.Id, admin.UserName, admin.FirstName, admin.LastName, admin.MailAdress, admin.Role, admin.LastLoginDate);
    }

    private PasswordVerificationResult VerifyPassword(DefAdmin admin, string password) =>
        string.IsNullOrEmpty(admin.PasswordHash)
            ? PasswordVerificationResult.Failed
            : passwordHasher.VerifyHashedPassword(admin, admin.PasswordHash, password);

    private AuthTokens IssueTokens(DefAdmin admin, DateTime now)
    {
        var (accessToken, accessExpiresAt) = tokenService.CreateAccessToken(admin, now);
        var refreshToken = tokenService.CreateRefreshToken();
        var refreshExpiresAt = now.AddDays(_options.RefreshTokenDays);

        refreshTokens.Add(AdminRefreshToken.Create(admin.Id, tokenService.HashRefreshToken(refreshToken), refreshExpiresAt));

        return new AuthTokens(accessToken, accessExpiresAt, refreshToken, refreshExpiresAt);
    }

    private async Task RevokeAllAsync(int adminId, DateTime now, CancellationToken cancellationToken)
    {
        var active = await refreshTokens.ListAsync(t => t.AdminId == adminId && t.RevokedAt == null, cancellationToken);
        foreach (var token in active)
            token.Revoke(now);
    }
}
