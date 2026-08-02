namespace FactoryPulse.Application.Interfaces;

public interface IDashboardNotifier
{
    Task NotifyDashboardUpdated(Guid machineId);
}