using Evently.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Evently.Modules.Events.Application.Abstractions.Messaging;

/// <summary>
/// Representa uma query do CQRS — operação de leitura, sem efeitos colaterais —
/// que retorna um <see cref="Result{TResponse}"/> com os dados solicitados.
/// </summary>
/// <typeparam name="TResponse">Tipo do dado devolvido pela query.</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
