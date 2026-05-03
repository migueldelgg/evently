using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

public abstract class CategoryEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateCategory.MapEndpoint(app);
        GetCategory.MapEndpoint(app);
    }
}
