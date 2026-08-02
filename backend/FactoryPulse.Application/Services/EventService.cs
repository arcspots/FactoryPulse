using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;

namespace FactoryPulse.Application.Services;

public class EventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(
        IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task RegisterAsync(
        Guid machineId,
        string type,
        string message)
    {
        var @event = new Event(
            machineId,
            type,
            message);

        await _eventRepository.AddAsync(@event);
    }
}