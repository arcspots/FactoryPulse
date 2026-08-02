using FactoryPulse.Domain.Enums;
namespace FactoryPulse.Domain.Entities;

public class Machine
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Sector { get; private set; } = string.Empty;

    public MachineStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public List<Telemetry> Telemetries { get; private set; } = [];

    public Machine(string name, string sector)

    

    {
        Id = Guid.NewGuid();
        Name = name;
        Sector = sector;
        Status = MachineStatus.Running;
        CreatedAt = DateTime.UtcNow;
    }
    

}