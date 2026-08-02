namespace FactoryPulse.Application.DTOs;

public class MachineHealthResponse
{
    public Guid MachineId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime? LastCommunication { get; set; }

    public int MinutesOffline { get; set; }

    public string Health { get; set; } = string.Empty;
}