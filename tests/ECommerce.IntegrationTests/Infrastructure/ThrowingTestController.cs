using Microsoft.AspNetCore.Mvc;

namespace ECommerce.IntegrationTests.Infrastructure;

[ApiController]
[Route("test/throw")]
public class ThrowingTestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => throw new InvalidOperationException("Test hatası");
}
