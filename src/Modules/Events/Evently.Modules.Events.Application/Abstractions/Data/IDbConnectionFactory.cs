using System.Data.Common;

namespace Evently.Modules.Events.Application.Abstractions.Data;

/// <summary>
/// Fábrica de conexões ADO.NET utilizada pelos handlers de query (lado de leitura do CQRS),
/// que executam SQL com Dapper sem passar pelo EF Core.
/// </summary>
public interface IDbConnectionFactory
{
    /// <summary>
    /// Abre e retorna uma <see cref="DbConnection"/> pronta para uso.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento da operação.</param>
    /// <returns>Conexão aberta; o chamador é responsável por descartá-la.</returns>
    ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken);
}
