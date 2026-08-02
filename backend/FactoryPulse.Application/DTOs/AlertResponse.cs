namespace FactoryPulse.Application.DTOs;

public class AlertResponse
{
    public Guid Id { get; set; }

    public Guid MachineId { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Severity { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}