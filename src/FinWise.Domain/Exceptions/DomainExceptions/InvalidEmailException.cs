namespace FinWise.Domain.Exceptions.DomainExceptions;

public class InvalidEmailException : DomainException
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}