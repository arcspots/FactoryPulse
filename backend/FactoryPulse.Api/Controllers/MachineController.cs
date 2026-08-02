using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachineController : ControllerBase
{
    private readonly MachineService _machineService;

    public MachineController(MachineService machineService)
    {
        _machineService = machineService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMachine([FromBody] MachineRequest request)
    {
        var machine = await _machineService.CreateMachineAsync(request);

        return CreatedAtAction(
            nameof(GetAllMachines),
            new { id = machine.Id },
            machine);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMachines()
    {
        var machines = await _machineService.GetAllMachinesAsync();

        return Ok(machines);
    }

    [HttpGet("{id}/telemetry")]
    public async Task<IActionResult> GetTelemetryHistory(Guid id)
    {
        var history = await _machineService.GetTelemetryHistoryAsync(id);

        return Ok(history);
    }

    [HttpGet("{id}/dashboard")]
    public async Task<IActionResult> GetDashboard(Guid id)
    {
        var dashboard = await _machineService.GetDashboardAsync(id);

        if (dashboard is null)
            return NotFound();

        return Ok(dashboard);
    }
}