using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;

[ApiController]
[Route("api/overview")]
public class OverviewController : ControllerBase
{
    private readonly OverviewService _overviewService;

    public OverviewController(
        OverviewService overviewService)
    {
        _overviewService = overviewService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var overview =
            await _overviewService.GetOverviewAsync();

        return Ok(overview);
    }
}