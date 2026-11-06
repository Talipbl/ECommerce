using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.IntegrationTests.Infrastructure;

public class ApiFactory(string connectionString, IReadOnlyDictionary<string, string?>? settings = null) : WebApplicationFactory<Program>
{
    public const string SigningKey = "integration-test-signing-key-0123456789abcdef";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:ECommerce", connectionString);
        builder.UseSetting("Trendyol:SellerId", "1");
        builder.UseSetting("Trendyol:ApiKey", "test-key");
        builder.UseSetting("Trendyol:ApiSecret", "test-secret");
        builder.UseSetting("Jwt:SigningKey", SigningKey);
        builder.UseSetting("RateLimiting:Auth:PermitLimit", "1000");

        foreach (var (key, value) in settings ?? new Dictionary<string, string?>())
            builder.UseSetting(key, value);

        builder.ConfigureTestServices(services =>
            services.AddControllers().AddApplicationPart(typeof(ApiFactory).Assembly));
    }
}
