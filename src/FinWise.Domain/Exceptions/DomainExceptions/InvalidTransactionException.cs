namespace FinWise.Domain.Exceptions.DomainExceptions;
public class InvalidTransactionException : DomainException
{
    public InvalidTransactionException(string message) : base(message)
    {
    }
}