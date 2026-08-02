namespace FactoryPulse.Application.DTOs;

public class MachineResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Sector { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}