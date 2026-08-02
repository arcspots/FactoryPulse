namespace FactoryPulse.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }

    public Guid MachineId { get; private set; }

    public string Type { get; private set; } = string.Empty;

    public string Message { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }


    public Event(
        Guid machineId,
        string type,
        string message)
    {
        Id = Guid.NewGuid();

        MachineId = machineId;

        Type = type;

        Message = message;

        CreatedAt = DateTime.UtcNow;
    }
}