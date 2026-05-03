using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Application.Abstractions.Messaging;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Domain.Categories;

namespace Evently.Modules.Events.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? existing = await categoryRepository.GetCategoryByNameAsync(request.Name, cancellationToken);
        if (existing is not null)
        {
            return Result.Failure<Guid>(CategoryErrors.AlreadyExist(existing.Id));
        }
        
        var category = Category.Create(request.Name);
        categoryRepository.Insert(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new Guid(category.Id.ToString());
    }
}
