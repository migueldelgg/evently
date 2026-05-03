namespace Evently.Modules.Events.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Category?> GetCategoryByNameAsync(string name, CancellationToken cancellationToken = default);

    void Insert(Category category);
}
