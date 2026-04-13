using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (Request request, EventsDbContext context) =>
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartsAtUtc = request.StartsAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                Status = EventStatus.Draft,
            };

            context.Events.Add(@event);

            await context.SaveChangesAsync();

            return Results.Ok(@event.Id);
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