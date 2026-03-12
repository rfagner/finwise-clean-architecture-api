using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Events;

public class UserRegisteredEvent : IDomainEvent
{
    public Guid EventId { get; }
    public DateTime OccurredAt { get; }
    public Guid UserId { get; }
    public Email Email { get; }
    public string Name { get; }

    public UserRegisteredEvent(Guid userId, Email email, string name)
    {
        EventId = Guid.NewGuid();
        OccurredAt = DateTime.UtcNow;
        UserId = userId;
        Email = email;
        Name = name;
    }
}