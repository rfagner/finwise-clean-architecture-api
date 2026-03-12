using FinWise.Domain.Entities;
using FinWise.Domain.Enums;

namespace FinWise.Domain.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Transaction>> GetByUserIdAndDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<Transaction>> GetByUserIdAndCategoryAsync(Guid userId, Guid categoryId);
    Task<IEnumerable<Transaction>> GetByUserIdAndTypeAsync(Guid userId, TransactionType type);
    Task<int> CountByUserIdAsync(Guid userId);
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}