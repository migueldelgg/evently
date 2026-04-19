using Evently.Modules.Events.Application.Events;
using Evently.Modules.Events.Application.Events.CreateEvent;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (Request request, ISender sender) =>
        {
            // 1. Cria o comando de acordo com a request, enviando somente os dados necessários para cumprir o use-case
            var command = new CreateEventCommand(
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc);
            
            // 2. Envia o comando
            Guid eventId = await sender.Send(command);
            
            // 3. Devolve o resultado
            return Results.Ok(eventId);
        })
        .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Location { get; set; }

        public DateTime StartsAtUtc { get; set; }

        public DateTime? EndsAtUtc { get; set; }
    }
}
