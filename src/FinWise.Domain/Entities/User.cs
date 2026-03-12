using FinWise.Domain.Common;
using FinWise.Domain.Events;
using FinWise.Domain.Exceptions.DomainExceptions;
using FinWise.Domain.ValueObjects;

namespace FinWise.Domain.Entities;

public class User : Entity
{
    public Email Email { get; private set; }
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private User() { }

    public User(Email email, string name, string passwordHash)
    {
        ValidateName(name);
        ValidatePasswordHash(passwordHash);

        Email = email ?? throw new ArgumentNullException(nameof(email));
        Name = name;
        PasswordHash = passwordHash;
        EmailConfirmed = false;
        CreatedAt = DateTime.UtcNow;

        AddDomainEvent(new UserRegisteredEvent(Id, Email, Name));
    }

    public void ConfirmEmail()
    {
        if (EmailConfirmed)
            throw new InvalidUserException("O email já foi confirmado");

        if (DeletedAt.HasValue)
            throw new InvalidUserException("Não é possível confirmar email de usuário excluído");

        EmailConfirmed = true;
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new EmailConfirmedEvent(Id, Email));
    }

    public void ChangePassword(string currentPasswordHash, string newPasswordHash)
    {
        if (DeletedAt.HasValue)
            throw new InvalidUserException("Não é possível alterar senha de usuário excluído");

        if (PasswordHash != currentPasswordHash)
            throw new InvalidUserException("A senha atual está incorreta");

        ValidatePasswordHash(newPasswordHash);

        if (newPasswordHash == currentPasswordHash)
            throw new InvalidUserException("A nova senha deve ser diferente da senha atual");

        PasswordHash = newPasswordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string newName)
    {
        if (DeletedAt.HasValue)
            throw new InvalidUserException("Não é possível atualizar nome de usuário excluído");

        ValidateName(newName);

        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        if (DeletedAt.HasValue)
            throw new InvalidUserException("O usuário já foi excluído");

        DeletedAt = DateTime.UtcNow;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidUserException("O nome não pode ser vazio");

        if (name.Length < 2)
            throw new InvalidUserException("O nome deve ter no mínimo 2 caracteres");

        if (name.Length > 100)
            throw new InvalidUserException("O nome não pode exceder 100 caracteres");
    }

    private static void ValidatePasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new InvalidUserException("O hash da senha não pode ser vazio");
    }
}