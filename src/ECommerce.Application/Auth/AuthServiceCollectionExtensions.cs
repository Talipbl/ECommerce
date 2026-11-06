using ECommerce.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ECommerce.Application.Auth;

public static class AuthServiceCollectionExtensions
{
    public static IServiceCollection AddAdminAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<AuthOptions>().Bind(configuration.GetSection(AuthOptions.SectionName));
        services.AddOptions<JwtOptions>()
            .Bind(configuration.GetSection(JwtOptions.SectionName))
            .Validate(o => o.HasValidSigningKey, "Jwt:SigningKey en az 32 bayt olmalı ve user-secrets veya ortam değişkeni ile tanımlanmalıdır.")
            .ValidateOnStart();

        services.TryAddSingleton(TimeProvider.System);
        services.AddSingleton<IPasswordHasher<DefAdmin>, PasswordHasher<DefAdmin>>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
