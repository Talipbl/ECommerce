using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.IntegrationTests.Infrastructure;

public class ApiFactory(string connectionString) : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:ECommerce", connectionString);
        builder.UseSetting("Trendyol:SellerId", "1");
        builder.UseSetting("Trendyol:ApiKey", "test-key");
        builder.UseSetting("Trendyol:ApiSecret", "test-secret");

        builder.ConfigureTestServices(services =>
            services.AddControllers().AddApplicationPart(typeof(ApiFactory).Assembly));
    }
}
