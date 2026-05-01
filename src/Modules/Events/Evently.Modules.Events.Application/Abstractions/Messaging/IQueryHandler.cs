using Evently.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Evently.Modules.Events.Application.Abstractions.Messaging;

/// <summary>
/// Handler que processa uma <see cref="IQuery{TResponse}"/> e devolve um
/// <see cref="Result{TResponse}"/> com os dados consultados.
/// </summary>
/// <typeparam name="TQuery">Tipo da query tratada.</typeparam>
/// <typeparam name="TResponse">Tipo do dado devolvido.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
