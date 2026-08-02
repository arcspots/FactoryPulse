using FactoryPulse.Application.Interfaces;

namespace FactoryPulse.Application.Services;

public class AlertService
{
    private readonly IAlertRepository _alertRepository;


    public AlertService(IAlertRepository alertRepository)
    {
        _alertRepository = alertRepository;
    }


    public async Task<List<object>> GetAllAsync()
    {
        var alerts = await _alertRepository.GetAllAsync();

        return alerts.Select(a => new
        {
            a.Id,
            a.MachineId,
            a.Message,
            Severity = a.Severity.ToString(),
            a.CreatedAt
        }).Cast<object>().ToList();
    }


    public async Task<List<object>> GetByMachineIdAsync(Guid machineId)
    {
        var alerts = await _alertRepository.GetByMachineIdAsync(machineId);

        return alerts.Select(a => new
        {
            a.Id,
            a.MachineId,
            a.Message,
            Severity = a.Severity.ToString(),
            a.CreatedAt
        }).Cast<object>().ToList();
    }
}