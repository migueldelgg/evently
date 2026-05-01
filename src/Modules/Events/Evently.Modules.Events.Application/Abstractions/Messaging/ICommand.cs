using Evently.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Evently.Modules.Events.Application.Abstractions.Messaging;

/// <summary>
/// Representa um command do CQRS que altera estado e retorna apenas um <see cref="Result"/>
/// indicando sucesso ou falha.
/// </summary>
public interface ICommand : IRequest<Result>, IBaseCommand;

/// <summary>
/// Representa um command do CQRS que altera estado e retorna um <see cref="Result{TResponse}"/>
/// com o valor produzido em caso de sucesso.
/// </summary>
/// <typeparam name="TResponse">Tipo do valor devolvido pelo command.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

/// <summary>
/// Marker compartilhado por <see cref="ICommand"/> e <see cref="ICommand{TResponse}"/>,
/// utilizado por behaviors do MediatR (validação, logging, transações) para identificar commands.
/// </summary>
public interface IBaseCommand;
