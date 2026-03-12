using FinWise.Domain.Exceptions.DomainExceptions;

namespace FinWise.Domain.ValueObjects;
public sealed class Money : IEquatable<Money>, IComparable<Money>
{
    public decimal Amount { get; }
    public Money(decimal amount)
    {
        if (amount < 0)
            throw new InvalidAmountException("O valor monetário não pode ser negativo");

        if (amount > 1_000_000)
            throw new InvalidAmountException("O valor monetário não pode exceder R$ 1.000.000,00");

        Amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
    }

    public Money Add(Money other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        return new Money(Amount + other.Amount);
    }    

    public Money Subtract(Money other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        return new Money(Amount - other.Amount);
    }

    public Money MultiplyBy(decimal factor)
    {
        return new Money(Amount * factor);
    }

    public Money DivideBy(decimal divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException("Não é possível dividor por zero");

        return new Money(Amount / divisor);
    }

    public bool Equals(Money? other)
    {
        if (other is null)
            return false;

        return Amount == other.Amount;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Money);
    }

    public override int GetHashCode()
    {
        return Amount.GetHashCode();
    }

    public int CompareTo(Money? other)
    {
        if (other is null)
            return 1;

        return Amount.CompareTo(other.Amount);
    }

    public static Money operator +(Money left, Money right)
    {
        return left.Add(right);
    }

    public static Money operator -(Money left, Money right)
    {
        return left.Subtract(right);
    }

    public static Money operator *(Money money, decimal factor)
    {
        return money.MultiplyBy(factor);
    }

    public static Money operator /(Money money, decimal divisor)
    {
        return money.DivideBy(divisor);
    }

    public static bool operator ==(Money left, Money right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Money left, Money right)
    {
        return !(left == right);
    }

    public static bool operator >(Money left, Money right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(Money left, Money right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(Money left, Money right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(Money left, Money right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static implicit operator decimal(Money money)
    {
        return money?.Amount ?? 0;
    }

    public static implicit operator Money(decimal amount)
    {
        return new Money(amount);
    }

    public override string ToString()
    {
        return Amount.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
    }

}