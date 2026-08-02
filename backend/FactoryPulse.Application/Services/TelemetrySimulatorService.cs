using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interfaces;
using FactoryPulse.Application.Simulators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FactoryPulse.Application.Services;

public class TelemetrySimulatorService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public TelemetrySimulatorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            var machineRepository =
                scope.ServiceProvider
                .GetRequiredService<IMachineRepository>();

            var telemetryService =
                scope.ServiceProvider
                .GetRequiredService<TelemetryService>();

            var machines =
                await machineRepository.GetAllAsync();

            foreach (var machine in machines)
            {
                var telemetry =
                    MachineTelemetrySimulator.Generate(machine.Id);

                await telemetryService.ReceiveTelemetryAsync(telemetry);
            }

            await Task.Delay(
                TimeSpan.FromSeconds(2),
                stoppingToken);
        }
    }
}