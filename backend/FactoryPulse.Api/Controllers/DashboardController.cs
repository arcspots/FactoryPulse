using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var statistics = await _dashboardService.GetStatisticsAsync();

        return Ok(statistics);
    }

    [HttpGet("machine/{machineId}/history")]
    public async Task<IActionResult> GetMachineHistory(Guid machineId)
    {
        var history = await _dashboardService.GetMachineHistoryAsync(machineId);

        return Ok(history);
    }
}