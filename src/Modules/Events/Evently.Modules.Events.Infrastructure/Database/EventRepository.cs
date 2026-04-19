using Evently.Modules.Events.Domain.Events;

namespace Evently.Modules.Events.Infrastructure.Database;

internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
        context.Add(@event);
    }
}
