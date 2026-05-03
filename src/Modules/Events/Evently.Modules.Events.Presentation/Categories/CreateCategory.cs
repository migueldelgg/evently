using Evently.Modules.Events.Application.Categories;
using Evently.Modules.Events.Application.Categories.CreateCategory;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

internal static class CreateCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (Request request, ISender sender) =>
        {
            // 1. Cria o comando e envia
            Result<Guid> result = await sender.Send(new CreateCategoryCommand(request.Name));
            
            // 2. Devolve o resultado
            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Category);
    }

    internal sealed class Request
    {
        public required string Name { get; set; }
    }
}
