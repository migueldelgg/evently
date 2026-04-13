using Evently.Modules.Events.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extensions;

internal static class MigrationsExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        ApplyMigrations<EventsDbContext>(scope);
    }

    private static void ApplyMigrations<TDBContext>(IServiceScope scope)
        where TDBContext : DbContext
    {
        using TDBContext context = scope.ServiceProvider.GetRequiredService<TDBContext>();
        
        context.Database.Migrate();
    }
}
