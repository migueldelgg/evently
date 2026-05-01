namespace Evently.Modules.Events.Application.Abstractions.Data;

/// <summary>
/// Representa uma unidade de trabalho transacional do lado de escrita do CQRS,
/// persistindo todas as mudanças acumuladas no contexto em uma única operação.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Confirma as alterações pendentes no armazenamento de dados.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento da operação.</param>
    /// <returns>Quantidade de registros afetados.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
