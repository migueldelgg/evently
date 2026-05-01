using Evently.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Evently.Modules.Events.Application.Abstractions.Messaging;

/// <summary>
/// Handler que processa um <see cref="ICommand"/> e devolve um <see cref="Result"/>.
/// </summary>
/// <typeparam name="TCommand">Tipo do command tratado.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

/// <summary>
/// Handler que processa um <see cref="ICommand{TResponse}"/> e devolve um
/// <see cref="Result{TResponse}"/> com o valor produzido.
/// </summary>
/// <typeparam name="TCommand">Tipo do command tratado.</typeparam>
/// <typeparam name="TResponse">Tipo do valor devolvido em caso de sucesso.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
