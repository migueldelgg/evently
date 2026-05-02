using Evently.Modules.Events.Application.Abstractions.Clock;
using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Categories;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Domain.TicketTypes;
using Evently.Modules.Events.Infrastructure.Categories;
using Evently.Modules.Events.Infrastructure.Clock;
using Evently.Modules.Events.Infrastructure.Data;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Infrastructure.TicketTypes;
using Evently.Modules.Events.Presentation.Categories;
using Evently.Modules.Events.Presentation.Events;
using Evently.Modules.Events.Presentation.TicketTypes;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        EventEndpoints.MapEndpoints(app);
        CategoryEndpoints.MapEndpoints(app);
        TicketTypesEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Resolve Dependency Injection for MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });
        
        // Resolve Dependency Injection for FluentValidation
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

        // Resolve Dependency Injection for Infrastructure
        services.AddInfrastructure(configuration);

        return services;
    }
    
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;
        
        // Resolve Dependency Injection for Dapper Open Connection
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        // Resolve Dependency Injection for EF Core
        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention());
        
        // Resolve Dependency Injection
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<EventsDbContext>());
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
