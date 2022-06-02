using Microsoft.AspNetCore.Mvc;

namespace web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public DemoController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Demo()
    {
        var client = new HttpClient() { BaseAddress = new Uri("https://localhost:7240") };
        var address = await client.GetStringAsync("api/address");
        return Ok(address);
    }
}
