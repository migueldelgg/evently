using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Presentation.ApiResults;

/// <summary>
/// Métodos de extensão que aplicam pattern matching sobre um <see cref="Result"/> ou
/// <see cref="Result{TValue}"/>, produzindo um único valor de saída a partir do
/// caminho de sucesso ou de falha.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Projeta um <see cref="Result"/> em um valor do tipo <typeparamref name="TOut"/>,
    /// invocando <paramref name="onSuccess"/> quando o resultado é bem-sucedido e
    /// <paramref name="onFailure"/> caso contrário.
    /// </summary>
    /// <typeparam name="TOut">O tipo produzido por ambos os caminhos.</typeparam>
    /// <param name="result">O resultado sendo avaliado.</param>
    /// <param name="onSuccess">Função invocada quando <paramref name="result"/> é bem-sucedido.</param>
    /// <param name="onFailure">Função invocada com o <paramref name="result"/> em estado de falha.</param>
    /// <returns>O valor produzido pelo caminho correspondente ao desfecho de <paramref name="result"/>.</returns>
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    /// <summary>
    /// Projeta um <see cref="Result{TValue}"/> em um valor do tipo <typeparamref name="TOut"/>,
    /// repassando o valor contido para <paramref name="onSuccess"/> quando bem-sucedido ou
    /// o resultado em falha para <paramref name="onFailure"/> caso contrário.
    /// </summary>
    /// <typeparam name="TIn">O tipo do valor carregado por um resultado bem-sucedido.</typeparam>
    /// <typeparam name="TOut">O tipo produzido por ambos os caminhos.</typeparam>
    /// <param name="result">O resultado sendo avaliado.</param>
    /// <param name="onSuccess">Função invocada com o valor de sucesso.</param>
    /// <param name="onFailure">Função invocada com o <paramref name="result"/> em estado de falha.</param>
    /// <returns>O valor produzido pelo caminho correspondente ao desfecho de <paramref name="result"/>.</returns>
    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}
