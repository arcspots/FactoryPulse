namespace FactoryPulse.Application.DTOs;

public class OverviewDto
{
    public int TotalMachines { get; set; }

    public int RunningMachines { get; set; }

    public int WarningMachines { get; set; }

    public int CriticalMachines { get; set; }

    public int OfflineMachines { get; set; }

    public int ActiveAlerts { get; set; }

    public double AverageTemperature { get; set; }

    public double AverageHealthScore { get; set; }

    public int TotalProduction { get; set; }

    public DateTime LastUpdate { get; set; }

    public List<OverviewMachineDto> Machines { get; set; } = new();


}