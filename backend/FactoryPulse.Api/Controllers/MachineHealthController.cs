using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MachineHealthController : ControllerBase
{

    private readonly MachineHealthService _service;


    public MachineHealthController(
        MachineHealthService service)
    {
        _service = service;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var health =
            await _service.GetHealthAsync(id);


        if (health is null)
            return NotFound();


        return Ok(health);
    }
}