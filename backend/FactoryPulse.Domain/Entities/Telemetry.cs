namespace FactoryPulse.Domain.Entities;

public class Telemetry
{
    public Guid Id { get; private set; }

    public Guid MachineId { get; private set; }

    public double Temperature { get; private set; }

    public double Pressure { get; private set; }

    public int Rpm { get; private set; }

    public int PiecesProduced { get; private set; }

    public DateTime Timestamp { get; private set; }


    public Telemetry(
        Guid machineId,
        double temperature,
        double pressure,
        int rpm,
        int piecesProduced)
    {
        Id = Guid.NewGuid();

        MachineId = machineId;

        Temperature = temperature;

        Pressure = pressure;

        Rpm = rpm;

        PiecesProduced = piecesProduced;

        Timestamp = DateTime.UtcNow;
    }
}