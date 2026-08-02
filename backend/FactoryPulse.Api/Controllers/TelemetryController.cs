using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelemetryController : ControllerBase
{
    private readonly TelemetryService _telemetryService;

    public TelemetryController(TelemetryService telemetryService)
    {
        _telemetryService = telemetryService;
    }

    [HttpPost]
    public async Task<IActionResult> ReceiveTelemetry([FromBody] TelemetryRequest request)
    {
        await _telemetryService.ReceiveTelemetryAsync(request);

        return Ok(new
        {
            Message = "Telemetria recebida e processada com sucesso."
        });
    }
}