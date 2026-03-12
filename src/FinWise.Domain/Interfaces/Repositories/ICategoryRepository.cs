using FinWise.Domain.Entities;

namespace FinWise.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllDefaultAsync();
    Task<IEnumerable<Category>> GetByUserIdAsync(Guid userId);
    Task<bool> ExistsByNameAndUserAsync(string name, Guid userId);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}