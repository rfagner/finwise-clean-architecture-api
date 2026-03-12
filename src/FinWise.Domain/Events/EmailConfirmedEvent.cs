using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Events;

public class EmailConfirmedEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime OccurredAt { get; }
    public Guid UserId { get; }
    public Email Email { get; }

    public EmailConfirmedEvent(Guid userId, Email email)
    {
        EventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
        UserId = userId;
        Email = email;
    }
}