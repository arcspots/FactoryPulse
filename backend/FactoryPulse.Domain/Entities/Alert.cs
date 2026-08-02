namespace FactoryPulse.Domain.Entities;

using FactoryPulse.Domain.Enums;

public class Alert
{
    public Guid Id { get; private set; }

    public Guid MachineId { get; private set; }

    public string Message { get; private set; } = string.Empty;

    public AlertSeverity Severity { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime? ResolvedAt { get; private set; }


    public Alert(
        Guid machineId,
        string message,
        AlertSeverity severity)
    {
        Id = Guid.NewGuid();

        MachineId = machineId;

        Message = message;

        Severity = severity;

        CreatedAt = DateTime.UtcNow;

        IsActive = true;
    }


    public void Resolve()
    {
        IsActive = false;

        ResolvedAt = DateTime.UtcNow;
    }
}