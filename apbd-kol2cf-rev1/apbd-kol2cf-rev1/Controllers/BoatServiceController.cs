using apbd_kol2cf_rev1.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_kol2cf_rev1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoatServiceController : ControllerBase
{
    private readonly IBoatServiceService _boatServiceService;

    public BoatServiceController(IBoatServiceService boatServiceService)
    {
        _boatServiceService = boatServiceService;
    }

    [HttpGet("client/{id:int}")]
    public async Task<IActionResult> GetClientInfo(int id)
    {
        return Ok(await _boatServiceService.GetClientByIdAsync(id));
    }
}