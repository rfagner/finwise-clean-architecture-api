using FinWise.Domain.Entities;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(Email email);
    Task<bool> ExistsByEmailAsync(Email email);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}