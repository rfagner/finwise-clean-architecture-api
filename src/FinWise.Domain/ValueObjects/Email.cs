using FinWise.Domain.Exceptions.DomainExceptions;

namespace FinWise.Domain.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException("O endereço de email não pode ser vazio");

        var normalizedValue = value.Trim().ToLowerInvariant();

        if (!IsValidEmail(normalizedValue))
            throw new InvalidEmailException($"O endereço de email '{value}' é inválido");

        if (normalizedValue.Length > 254)
            throw new InvalidEmailException("O endereço de email não pode exceder 254 caracteres");

        Value = normalizedValue;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public bool Equals(Email other)
    {
        if (other is null)
            return false;

        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Email);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Email left, Email right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Email left, Email right)
    {
        return !(left == right);
    }

    public static implicit operator string(Email email)
    {
        return email?.Value;
    }

    public static implicit operator Email(string value)
    {
        return new Email(value);
    }

    public override string ToString()
    {
        return Value;
    }
}