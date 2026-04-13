namespace Evently.Modules.Events.Api.Events;

public enum EventStatus
{
    Draft = 0,
    Published = 1, // Usuários só deveram visualizar eventos Published
    Completed = 2,
    Canceled = 3
}
