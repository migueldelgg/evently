using Evently.Modules.Events.Application.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

internal static class GetCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("category/{id}", async (Guid id, ISender sender) =>
            {
                return id;
            })
            .WithTags(Tags.Category);
    }
}
