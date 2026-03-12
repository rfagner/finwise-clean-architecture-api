namespace FinWise.Domain.Exceptions.DomainExceptions;

public class InvalidAmountException : DomainException
{
    public InvalidAmountException(string message) : base(message)
    {
    }
}