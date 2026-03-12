using FinWise.Domain.Enums;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Events;

public class TransactionCreatedEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime OccurredAt { get; }
    public Guid TransactionId { get; }
    public Guid UserId { get; }
    public Money Amount { get; }
    public TransactionType Type { get; }
    public TransactionDate Date { get; }

    public TransactionCreatedEvent(
        Guid transactionId,
        Guid userId,
        Money amount,
        TransactionType type,
        TransactionDate date)
    {
        EventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
        TransactionId = transactionId;
        UserId = userId;
        Amount = amount;
        Type = type;
        Date = date;
    }
}