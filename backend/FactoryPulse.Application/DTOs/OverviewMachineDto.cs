namespace FactoryPulse.Application.DTOs;

public class OverviewMachineDto
{
    public Guid MachineId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Sector { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string HealthStatus { get; set; } = string.Empty;

    public double HealthScore { get; set; }

    public double Temperature { get; set; }

    public double Pressure { get; set; }

    public double RPM { get; set; }

    public int PiecesProduced { get; set; }

    public int ActiveAlerts { get; set; }

    public DateTime LastTelemetryAt { get; set; }
}