namespace FactoryPulse.Application.DTOs;

public class MachineDashboardResponse
{
    public Guid MachineId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Sector { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string HealthStatus { get; set; } = string.Empty;

    public int HealthScore { get; set; }

    public double? LastTemperature { get; set; }

    public double? LastPressure { get; set; }

    public int? LastRPM { get; set; }

    public int? LastPiecesProduced { get; set; }

    public DateTime? LastTelemetryAt { get; set; }

    public int ActiveAlerts { get; set; }

    public List<AlertResponse> Alerts { get; set; } = new();

    public List<TelemetryResponse> RecentTelemetry { get; set; } = new();
}