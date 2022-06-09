using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public DemoController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<IActionResult> Demo()
    {
        var client = new HttpClient() { BaseAddress = new Uri(_configuration["ExternalAPIHost"]) };
        var address = await client.GetStringAsync("api/address");
        return Ok(address);
    }
}
