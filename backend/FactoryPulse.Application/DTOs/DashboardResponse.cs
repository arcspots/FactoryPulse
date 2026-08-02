namespace FactoryPulse.Application.DTOs;

public class DashboardResponse
{
    public DateTime GeneratedAt { get; set; }

    public DashboardStatisticsResponse Statistics { get; set; } = null!;

    public List<MachineDashboardResponse> Machines { get; set; } = [];
}