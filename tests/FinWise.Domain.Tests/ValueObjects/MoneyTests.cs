using FinWise.Domain.Exceptions.DomainExceptions;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Tests.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Money_Should_Create_With_Valid_Amount()
    {
        var money = new Money(100.50m);
        Assert.Equal(100.50m, money.Amount);
    }

    [Fact]
    public void Money_Should_Round_To_Two_Decimal_Places()
    {
        var money = new Money(100.555m);
        Assert.Equal(100.56m, money.Amount);
    }

    [Fact]
    public void Money_Should_Throw_Exception_For_Negative_Amount()
    {
        Assert.Throws<InvalidAmountException>(() => new Money(-10));
    }

    [Fact]
    public void Money_Should_Throw_Exception_For_Amount_Exceeding_Limit()
    {
        Assert.Throws<InvalidAmountException>(() => new Money(2_000_000));
    }

    [Fact]
    public void Money_Add_Should_Return_New_Money_With_Sum()
    {
        var money1 = new Money(100);
        var money2 = new Money(50);
        var result = money1.Add(money2);
        Assert.Equal(150, result.Amount);
    }

    [Fact]
    public void Money_Subtract_Should_Return_New_Money_With_Difference()
    {
        var money1 = new Money(100);
        var money2 = new Money(30);
        var result = money1.Subtract(money2);
        Assert.Equal(70, result.Amount);
    }

    [Fact]
    public void Money_Equals_Should_Compare_By_Value()
    {
        var money1 = new Money(100);
        var money2 = new Money(100);
        Assert.True(money1.Equals(money2));
    }
}