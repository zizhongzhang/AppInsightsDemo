using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{

    private readonly ILogger<CountryController> _logger;

    public CountryController(ILogger<CountryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetCountries()
    {
        return Ok();
    }
}
