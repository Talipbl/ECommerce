using ECommerce.Application.Auth;
using ECommerce.Application.Common;
using ECommerce.Core.Persistence;
using ECommerce.Customers;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace ECommerce.Application.Customers;

public record RegisterCustomerRequest(string Email, string Password, string FirstName, string LastName, string? Phone);

public record UpdateCustomerProfileRequest(string FirstName, string LastName, string? Phone);

public record CustomerProfileDto(int Id, string Email, string FirstName, string LastName, string? Phone);

public record SaveAddressRequest(string Title, string FullName, string Phone, string City, string District, string AddressLine, string? PostalCode);

public record AddressDto(int Id, string Title, string FullName, string Phone, string City, string District, string AddressLine, string? PostalCode, bool IsDefault);

public interface ICustomerAuthService
{
    Task<Result<AuthTokens>> RegisterAsync(RegisterCustomerRequest request, CancellationToken cancellationToken = default);
    Task<AuthResult<AuthTokens>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<AuthResult<AuthTokens>> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<AuthResult<bool>> ChangePasswordAsync(int customerId, ChangePasswordRequest request, CancellationToken cancellationToken = default);
    Task<CustomerProfileDto?> GetProfileAsync(int customerId, CancellationToken cancellationToken = default);
    Task<Result<CustomerProfileDto>> UpdateProfileAsync(int customerId, UpdateCustomerProfileRequest request, CancellationToken cancellationToken = default);
}

public class CustomerAuthService(
    IRepository<Customer> customers,
    IRepository<CustomerRefreshToken> refreshTokens,
    IUnitOfWork unitOfWork,
    IPasswordHasher<Customer> passwordHasher,
    ITokenService tokenService,
    IOptions<AuthOptions> options,
    TimeProvider clock)
    : AccountAuthService<Customer, CustomerRefreshToken>(customers, refreshTokens, unitOfWork, passwordHasher, tokenService, options, clock), ICustomerAuthService
{
    public async Task<Result<AuthTokens>> RegisterAsync(RegisterCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var email = Customer.NormalizeEmail(request.Email);
        if (await Accounts.AnyAsync(c => c.Email == email, cancellationToken))
            return Result<AuthTokens>.Conflict("Bu e-posta adresiyle kayıtlı bir hesap var.");

        var customer = Customer.Register(email, request.FirstName, request.LastName, request.Phone);
        customer.PasswordHash = HashPassword(customer, request.Password);
        customer.RegisterSuccessfulLogin(Now);
        Accounts.Add(customer);
        await UnitOfWork.SaveChangesAsync(cancellationToken);

        // Kayıt sonrası otomatik giriş; token için müşterinin Id'si gerektiğinden ikinci kayıt yapılır.
        var tokens = IssueTokens(customer, Now);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result<AuthTokens>.Success(tokens);
    }

    public async Task<CustomerProfileDto?> GetProfileAsync(int customerId, CancellationToken cancellationToken = default)
    {
        var customer = await Accounts.GetByIdAsync(customerId, cancellationToken);
        return customer is null ? null : ToDto(customer);
    }

    public async Task<Result<CustomerProfileDto>> UpdateProfileAsync(int customerId, UpdateCustomerProfileRequest request, CancellationToken cancellationToken = default)
    {
        var customer = await Accounts.GetByIdAsync(customerId, cancellationToken);
        if (customer is null)
            return Result<CustomerProfileDto>.NotFound("Müşteri bulunamadı.");

        customer.UpdateProfile(request.FirstName, request.LastName, request.Phone);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result<CustomerProfileDto>.Success(ToDto(customer));
    }

    protected override Expression<Func<Customer, bool>> LoginEquals(string login)
    {
        var email = Customer.NormalizeEmail(login);
        return c => c.Email == email;
    }

    protected override Expression<Func<CustomerRefreshToken, bool>> TokenHashEquals(string tokenHash) => t => t.TokenHash == tokenHash;

    protected override Expression<Func<CustomerRefreshToken, bool>> ActiveTokensOf(int accountId) => t => t.CustomerId == accountId && t.RevokedAt == null;

    private static CustomerProfileDto ToDto(Customer c) => new(c.Id, c.Email, c.FirstName, c.LastName, c.Phone);
}

public interface ICustomerAddressService
{
    Task<IReadOnlyList<AddressDto>> ListAsync(int customerId, CancellationToken cancellationToken = default);
    Task<Result<AddressDto>> AddAsync(int customerId, SaveAddressRequest request, CancellationToken cancellationToken = default);
    Task<Result<AddressDto>> UpdateAsync(int customerId, int addressId, SaveAddressRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(int customerId, int addressId, CancellationToken cancellationToken = default);
    Task<Result<bool>> SetDefaultAsync(int customerId, int addressId, CancellationToken cancellationToken = default);
}

public class CustomerAddressService(IRepository<Customer> customers, IUnitOfWork unitOfWork) : ICustomerAddressService
{
    public async Task<IReadOnlyList<AddressDto>> ListAsync(int customerId, CancellationToken cancellationToken = default)
    {
        var customer = await customers.FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);
        return customer is null ? [] : customer.Addresses.OrderByDescending(a => a.IsDefault).ThenBy(a => a.Id).Select(ToDto).ToList();
    }

    public async Task<Result<AddressDto>> AddAsync(int customerId, SaveAddressRequest r, CancellationToken cancellationToken = default)
    {
        var customer = await customers.FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);
        if (customer is null)
            return Result<AddressDto>.NotFound("Müşteri bulunamadı.");

        var address = customer.AddAddress(r.Title, r.FullName, r.Phone, r.City, r.District, r.AddressLine, r.PostalCode);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<AddressDto>.Success(ToDto(address));
    }

    public Task<Result<AddressDto>> UpdateAsync(int customerId, int addressId, SaveAddressRequest r, CancellationToken cancellationToken = default) =>
        WithAddressAsync(customerId, addressId, (_, a) =>
        {
            a.Update(r.Title, r.FullName, r.Phone, r.City, r.District, r.AddressLine, r.PostalCode);
            return ToDto(a);
        }, cancellationToken);

    public async Task<Result<bool>> DeleteAsync(int customerId, int addressId, CancellationToken cancellationToken = default)
    {
        var result = await WithAddressAsync(customerId, addressId, (c, a) =>
        {
            c.RemoveAddress(a);
            return true;
        }, cancellationToken);
        return result;
    }

    public Task<Result<bool>> SetDefaultAsync(int customerId, int addressId, CancellationToken cancellationToken = default) =>
        WithAddressAsync(customerId, addressId, (c, a) =>
        {
            c.SetDefaultAddress(a);
            return true;
        }, cancellationToken);

    private async Task<Result<T>> WithAddressAsync<T>(int customerId, int addressId, Func<Customer, CustomerAddress, T> change, CancellationToken cancellationToken)
    {
        var customer = await customers.FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken);
        var address = customer?.Addresses.FirstOrDefault(a => a.Id == addressId);
        if (customer is null || address is null)
            return Result<T>.NotFound("Adres bulunamadı.");

        var value = change(customer, address);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<T>.Success(value);
    }

    internal static AddressDto ToDto(CustomerAddress a) =>
        new(a.Id, a.Title, a.FullName, a.Phone, a.City, a.District, a.AddressLine, a.PostalCode, a.IsDefault);
}

public class RegisterCustomerRequestValidator : AbstractValidator<RegisterCustomerRequest>
{
    public RegisterCustomerRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(128)
            .Matches("[A-Za-zÇĞİÖŞÜçğıöşü]").WithMessage("Parola en az bir harf içermelidir.")
            .Matches("[0-9]").WithMessage("Parola en az bir rakam içermelidir.");
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Phone).MaximumLength(20);
    }
}

public class UpdateCustomerProfileRequestValidator : AbstractValidator<UpdateCustomerProfileRequest>
{
    public UpdateCustomerProfileRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Phone).MaximumLength(20);
    }
}

public class SaveAddressRequestValidator : AbstractValidator<SaveAddressRequest>
{
    public SaveAddressRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20).Matches("^[0-9+ ()-]+$").WithMessage("Telefon numarası geçersiz.");
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.District).NotEmpty().MaximumLength(50);
        RuleFor(x => x.AddressLine).NotEmpty().MaximumLength(300);
        RuleFor(x => x.PostalCode).MaximumLength(10);
    }
}
