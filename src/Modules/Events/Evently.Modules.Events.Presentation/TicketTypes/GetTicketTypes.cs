using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal static class GetTicketTypes
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types/{id}", async (Guid id, ISender sender) =>
            {
                return id;
            })
            .WithTags(Tags.TicketTypes);
    }
}
