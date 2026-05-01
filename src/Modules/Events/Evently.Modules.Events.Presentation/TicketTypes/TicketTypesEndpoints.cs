using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

public static class TicketTypesEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        GetTicketTypes.MapEndpoint(app);
    }
}
