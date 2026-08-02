using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertController : ControllerBase
{
    private readonly AlertService _alertService;

    public AlertController(AlertService alertService)
    {
        _alertService = alertService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alerts = await _alertService.GetAllAsync();

        return Ok(alerts);
    }


    [HttpGet("machine/{machineId}")]
    public async Task<IActionResult> GetByMachine(Guid machineId)
    {
        var alerts = await _alertService.GetByMachineIdAsync(machineId);

        return Ok(alerts);
    }
}