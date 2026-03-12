namespace FinWise.Domain.Exceptions.DomainExceptions;
public class InvalidDateException : DomainException
{
    public InvalidDateException(string message) : base(message)
    {
    }
}