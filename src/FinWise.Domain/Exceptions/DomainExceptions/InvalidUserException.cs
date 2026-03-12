namespace FinWise.Domain.Exceptions.DomainExceptions;
public class InvalidUserException : DomainException
{
    public InvalidUserException(string message) : base(message)
    {
    }
}