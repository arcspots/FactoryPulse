using FactoryPulse.Api.Hubs;
using FactoryPulse.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FactoryPulse.Api.Hubs;

public class DashboardNotifier : IDashboardNotifier
{
    private readonly IHubContext<DashboardHub> _hub;

    public DashboardNotifier(IHubContext<DashboardHub> hub)
    {
        _hub = hub;
    }

    public async Task NotifyDashboardUpdated(Guid machineId)

    {
        Console.WriteLine($"Enviando evento SignalR da máquina {machineId}");

        await _hub.Clients.All.SendAsync(
            "DashboardUpdated",
            machineId);
    }
}