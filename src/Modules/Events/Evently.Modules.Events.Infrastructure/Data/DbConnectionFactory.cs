using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource datasource) 
    : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken)
    {
        return await datasource.OpenConnectionAsync(cancellationToken);
    }
}
