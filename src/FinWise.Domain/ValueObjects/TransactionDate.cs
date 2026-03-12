using FinWise.Domain.Exceptions.DomainExceptions;

namespace FinWise.Domain.ValueObjects;

public sealed class TransactionDate : IEquatable<TransactionDate>, IComparable<TransactionDate>
{
    public DateTime Value { get; }

    public TransactionDate(DateTime value)
    {
        if (value > DateTime.UtcNow.AddYears(1))
            throw new InvalidDateException(
                "A data da transação não pode ser superior a 1 ano no futuro");

        Value = value.Date;
    }

    public bool IsInFuture()
    {
        return Value.Date > DateTime.UtcNow.Date;
    }

    public bool IsPast()
    {
        return Value.Date < DateTime.UtcNow.Date;
    }

    public bool IsToday()
    {
        return Value.Date == DateTime.UtcNow.Date;
    }

    public bool Equals(TransactionDate other)
    {
        if (other is null)
            return false;

        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as TransactionDate);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public int CompareTo(TransactionDate other)
    {
        if (other is null)
            return 1;

        return Value.CompareTo(other.Value);
    }

    public static implicit operator DateTime(TransactionDate date)
    {
        return date?.Value ?? default;
    }

    public static implicit operator TransactionDate(DateTime value)
    {
        return new TransactionDate(value);
    }

    public override string ToString()
    {
        return Value.ToString("dd/MM/yyyy");
    }
}