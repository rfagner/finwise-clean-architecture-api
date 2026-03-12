using FinWise.Domain.Exceptions.DomainExceptions;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Tests.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Email_Should_Create_With_Valid_Address()
    {
        var email = new Email("user@example.com");
        Assert.Equal("user@example.com", email.Value);
    }

    [Fact]
    public void Email_Should_Normalize_To_Lowercase()
    {
        var email = new Email("USER@EXAMPLE.COM");
        Assert.Equal("user@example.com", email.Value);
    }

    [Fact]
    public void Email_Should_Throw_Exception_For_Empty_Value()
    {
        Assert.Throws<InvalidEmailException>(() => new Email(""));
    }

    [Fact]
    public void Email_Should_Throw_Exception_For_Invalid_Format()
    {
        Assert.Throws<InvalidEmailException>(() => new Email("invalid-email"));
    }

    [Fact]
    public void Email_Equals_Should_Compare_By_Value()
    {
        var email1 = new Email("user@example.com");
        var email2 = new Email("USER@example.com");
        Assert.True(email1.Equals(email2));
    }
}