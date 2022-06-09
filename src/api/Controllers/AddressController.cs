using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{

    private readonly ILogger<AddressController> _logger;
    private readonly ContactContext _dbContext;

    public AddressController(ILogger<AddressController> logger, ContactContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAddress()
    {
        return Ok(_dbContext.Address.FirstOrDefault());
    }
}
