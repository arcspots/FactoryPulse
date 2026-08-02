namespace FactoryPulse.Application.DTOs;

public class TelemetryResponse
{
    public double Temperature { get; set; }

    public double Pressure { get; set; }

    public int Rpm { get; set; }

    public int PiecesProduced { get; set; }

    public DateTime Timestamp { get; set; }
}