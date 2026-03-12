using FinWise.Domain.Common;
using FinWise.Domain.Enums;
using FinWise.Domain.Events;
using FinWise.Domain.Exceptions.DomainExceptions;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Entities;

public class Transaction : Entity
{
    public Guid UserId { get; private set; }
    public Money Amount { get; private set; }
    public Description Description { get; private set; }
    public TransactionType Type { get; private set; }
    public TransactionDate Date { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Notes { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Transaction() { }

    public Transaction(
        Guid userId,
        Money amount,
        Description description,
        TransactionType type,
        TransactionDate date,
        Guid categoryId,
        string notes = null)
    {
        if (userId == Guid.Empty)
            throw new InvalidTransactionException("O ID do usuário não pode ser vazio");

        if (categoryId == Guid.Empty)
            throw new InvalidTransactionException("O ID da categoria não pode ser vazio");

        UserId = userId;
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Type = type;
        Date = date ?? throw new ArgumentNullException(nameof(date));
        CategoryId = categoryId;
        Notes = notes?.Trim();
        CreatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionCreatedEvent(Id, UserId, Amount, Type, Date));
    }

    public void UpdateAmount(Money newAmount)
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException(
                "Não é possível atualizar transação excluída");

        Amount = newAmount ?? throw new ArgumentNullException(nameof(newAmount));
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionUpdatedEvent(Id, UserId));
    }

    public void UpdateDescription(Description newDescription)
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException(
                "Não é possível atualizar transação excluída");

        Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionUpdatedEvent(Id, UserId));
    }

    public void UpdateDate(TransactionDate newDate)
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException(
                "Não é possível atualizar transação excluída");

        Date = newDate ?? throw new ArgumentNullException(nameof(newDate));
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionUpdatedEvent(Id, UserId));
    }

    public void UpdateCategory(Guid newCategoryId)
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException(
                "Não é possível atualizar transação excluída");

        if (newCategoryId == Guid.Empty)
            throw new InvalidTransactionException("O ID da categoria não pode ser vazio");

        CategoryId = newCategoryId;
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionUpdatedEvent(Id, UserId));
    }

    public void UpdateNotes(string newNotes)
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException(
                "Não é possível atualizar transação excluída");

        Notes = newNotes?.Trim();
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionUpdatedEvent(Id, UserId));
    }

    public void Delete()
    {
        if (DeletedAt.HasValue)
            throw new InvalidTransactionException("A transação já foi excluída");

        DeletedAt = DateTime.UtcNow;

        AddDomainEvent(new TransactionDeletedEvent(Id, UserId));
    }

    public bool IsIncome()
    {
        return Type == TransactionType.Income;
    }

    public bool IsExpense()
    {
        return Type == TransactionType.Expense;
    }

    public bool IsFuture()
    {
        return Date.IsInFuture();
    }

    public bool IsPast()
    {
        return Date.IsPast();
    }

    public bool IsDeleted()
    {
        return DeletedAt.HasValue;
    }
}