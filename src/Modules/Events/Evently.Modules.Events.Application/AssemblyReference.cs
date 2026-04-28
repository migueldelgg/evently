using System.Reflection;

namespace Evently.Modules.Events.Application;

/// <summary>
/// Âncora para obter o <see cref="System.Reflection.Assembly"/> deste módulo
/// sem depender de um tipo específico que pode ser movido ou renomeado.
/// </summary>
/// <remarks>
/// Use em registros que fazem varredura de assembly — por exemplo,
/// MediatR (<c>RegisterServicesFromAssembly</c>) e FluentValidation
/// (<c>AddValidatorsFromAssembly</c>). Por convenção, cada módulo
/// (Application, Infrastructure, Presentation) expõe o seu próprio
/// <c>AssemblyReference</c>.
/// </remarks>
public static class AssemblyReference
{
    /// <summary>
    /// Referência ao assembly <c>Evently.Modules.Events.Application</c>,
    /// usada por componentes que descobrem handlers, validadores e
    /// behaviors por reflexão.
    /// </summary>
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
