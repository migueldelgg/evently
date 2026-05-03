using Evently.Modules.Events.Application.Events.CreateEvent;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Presentation.ApiResults;
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
            // 1. Cria o comando de acordo com a request e Envia o comando
            Result<Guid> result = await sender.Send(new CreateEventCommand(
                request.CategoryId,
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc));
            
            // 2. Devolve o resultado
            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public required Guid CategoryId { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Location { get; set; }

        public DateTime StartsAtUtc { get; set; }

        public DateTime? EndsAtUtc { get; set; }
    }
}
