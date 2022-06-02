using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{

    private readonly ILogger<AddressController> _logger;

    public AddressController(ILogger<AddressController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAddress()
    {
        return Ok("Australia");
    }
}
