namespace FactoryPulse.Application.DTOs;

public class TelemetryRequest
{
    public Guid MachineId { get; set; }

    public double Temperature { get; set; }

    public double Pressure { get; set; }

    public int RPM { get; set; }

    public int PiecesProduced { get; set; }


    // Métricas do monitoramento em tempo real
    public double CpuUsage { get; set; }

    public double MemoryUsage { get; set; }

    public double Vibration { get; set; }

    public int Rpm { get; set; }
}