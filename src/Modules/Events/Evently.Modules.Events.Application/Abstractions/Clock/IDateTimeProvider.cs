namespace Evently.Modules.Events.Application.Abstractions.Clock;

/// <summary>
/// Abstrai o acesso à data/hora atual, permitindo substituí-la em testes
/// sem depender diretamente de <see cref="DateTime.UtcNow"/>.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>Data e hora atuais em UTC.</summary>
    DateTime UtcNow { get; }
}
