using FinWise.Domain.Entities;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Services;

public class BalanceCalculator
{
    public Money CalculateCurrentBalance(IEnumerable<Transaction> transactions)
    {
        if (transactions is null)
            throw new ArgumentNullException(nameof(transactions));

        var validTransactions = transactions
            .Where(t => !t.IsDeleted() && !t.IsFuture())
            .ToList();

        if (!validTransactions.Any())
            return new Money(0);

        var incomes = validTransactions
            .Where(t => t.IsIncome())
            .Sum(t => t.Amount.Amount);

        var expenses = validTransactions
            .Where(t => t.IsExpense())
            .Sum(t => t.Amount.Amount);

        return new Money(incomes - expenses);
    }

    public Money CalculateProjectedBalance(IEnumerable<Transaction> transactions)
    {
        if (transactions is null)
            throw new ArgumentNullException(nameof(transactions));

        var validTransactions = transactions
            .Where(t => !t.IsDeleted())
            .ToList();

        if (!validTransactions.Any())
            return new Money(0);

        var incomes = validTransactions
            .Where(t => t.IsIncome())
            .Sum(t => t.Amount.Amount);

        var expenses = validTransactions
            .Where(t => t.IsExpense())
            .Sum(t => t.Amount.Amount);

        return new Money(incomes - expenses);
    }

    public Money CalculateBalanceByCategory(
        IEnumerable<Transaction> transactions,
        Guid categoryId)
    {
        if (transactions is null)
            throw new ArgumentNullException(nameof(transactions));

        var categoryTransactions = transactions
            .Where(t => !t.IsDeleted() && !t.IsFuture() && t.CategoryId == categoryId)
            .ToList();

        if (!categoryTransactions.Any())
            return new Money(0);

        var incomes = categoryTransactions
            .Where(t => t.IsIncome())
            .Sum(t => t.Amount.Amount);

        var expenses = categoryTransactions
            .Where(t => t.IsExpense())
            .Sum(t => t.Amount.Amount);

        return new Money(incomes - expenses);
    }

    public Dictionary<Guid, Money> CalculateBalanceByCategories(
        IEnumerable<Transaction> transactions)
    {
        if (transactions is null)
            throw new ArgumentNullException(nameof(transactions));

        var validTransactions = transactions
            .Where(t => !t.IsDeleted() && !t.IsFuture())
            .ToList();

        return validTransactions
            .GroupBy(t => t.CategoryId)
            .ToDictionary(
                g => g.Key,
                g => CalculateBalanceByCategory(g, g.Key)
            );
    }
}