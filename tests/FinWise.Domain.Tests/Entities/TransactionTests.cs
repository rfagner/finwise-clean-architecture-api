using FinWise.Domain.Entities;
using FinWise.Domain.Enums;
using FinWise.Domain.Events;
using FinWise.Domain.Exceptions.DomainExceptions;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Tests.Entities;

public class TransactionTests
{
    [Fact]
    public void Transaction_Should_Create_With_Valid_Data()
    {
        var userId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();
        var amount = new Money(100);
        var description = new Description("Almoço");
        var date = new TransactionDate(DateTime.UtcNow);

        var transaction = new Transaction(
            userId,
            amount,
            description,
            TransactionType.Expense,
            date,
            categoryId
        );

        Assert.NotEqual(Guid.Empty, transaction.Id);
        Assert.Equal(userId, transaction.UserId);
        Assert.Equal(amount, transaction.Amount);
    }

    [Fact]
    public void Transaction_Should_Throw_Exception_For_Empty_UserId()
    {
        Assert.Throws<InvalidTransactionException>(() =>
            new Transaction(
                Guid.Empty,
                new Money(100),
                new Description("Test"),
                TransactionType.Expense,
                new TransactionDate(DateTime.UtcNow),
                Guid.NewGuid()
            )
        );
    }

    [Fact]
    public void Transaction_UpdateAmount_Should_Change_Amount()
    {
        var transaction = CreateValidTransaction();
        var newAmount = new Money(200);

        transaction.UpdateAmount(newAmount);

        Assert.Equal(newAmount, transaction.Amount);
    }

    [Fact]
    public void Transaction_Delete_Should_Mark_As_Deleted()
    {
        var transaction = CreateValidTransaction();

        transaction.Delete();

        Assert.True(transaction.IsDeleted());
    }

    [Fact]
    public void Transaction_Should_Add_Domain_Event_On_Creation()
    {
        var transaction = CreateValidTransaction();

        Assert.Single(transaction.DomainEvents);
        Assert.IsType<TransactionCreatedEvent>(transaction.DomainEvents.First());
    }

    private Transaction CreateValidTransaction()
    {
        return new Transaction(
            Guid.NewGuid(),
            new Money(100),
            new Description("Test Transaction"),
            TransactionType.Expense,
            new TransactionDate(DateTime.UtcNow),
            Guid.NewGuid()
        );
    }
}