using FinWise.Domain.Exceptions;

namespace FinWise.Domain.ValueObjects;

public sealed class Description : IEquatable<Description>
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("A descrição não pode ser vazia");

        var trimmedValue = value.Trim();

        if (trimmedValue.Length < 3)
            throw new DomainException("A descrição deve ter no mínimo 3 caracteres");

        if (trimmedValue.Length > 200)
            throw new DomainException("A descrição não pode exceder 200 caracteres");

        Value = trimmedValue;
    }

    public bool Equals(Description other)
    {
        if (other is null)
            return false;

        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Description);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static implicit operator string(Description description)
    {
        return description?.Value;
    }

    public static implicit operator Description(string value)
    {
        return new Description(value);
    }

    public override string ToString()
    {
        return Value;
    }
}