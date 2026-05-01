using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Application.Abstractions.Exceptions;

/// <summary>
/// Exceção da camada de aplicação que envelopa falhas ocorridas no processamento
/// de um command ou query, preservando o nome da requisição e o <see cref="Error"/>
/// de domínio associado.
/// </summary>
public sealed class EventlyException : Exception
{
    /// <summary>
    /// Cria uma nova <see cref="EventlyException"/>.
    /// </summary>
    /// <param name="requestName">Nome do command/query que originou a falha.</param>
    /// <param name="error">Erro de domínio relacionado, quando houver.</param>
    /// <param name="innerException">Exceção original capturada, quando houver.</param>
    public EventlyException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    /// <summary>Nome do command ou query que disparou a exceção.</summary>
    public string RequestName { get; }

    /// <summary>Erro de domínio associado, se aplicável.</summary>
    public Error? Error { get; }
}
