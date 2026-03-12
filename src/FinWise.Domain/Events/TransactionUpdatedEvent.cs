namespace FinWise.Domain.Events;

public class TransactionUpdatedEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime OccurredAt { get; }
    public Guid TransactionId { get; }
    public Guid UserId { get; }

    public TransactionUpdatedEvent(Guid transactionId, Guid userId)
    {
        EventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
        TransactionId = transactionId;
        UserId = userId;
    }
}