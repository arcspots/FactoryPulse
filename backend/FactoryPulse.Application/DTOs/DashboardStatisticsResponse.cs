namespace FactoryPulse.Application.DTOs;

public class DashboardStatisticsResponse
{
    public int TotalMachines { get; set; }

    public int RunningMachines { get; set; }

    public int StoppedMachines { get; set; }

    public int MaintenanceMachines { get; set; }

    public int TotalAlerts { get; set; }

    public int CriticalAlerts { get; set; }

    public double AverageTemperature { get; set; }

    public double AveragePressure { get; set; }

    public double AverageRPM { get; set; }

    public double MaxTemperature { get; set; }

    public double MinTemperature { get; set; }

    public int TotalProduction { get; set; }
}