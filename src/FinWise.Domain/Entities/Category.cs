using FinWise.Domain.Common;
using FinWise.Domain.Exceptions;

namespace FinWise.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public string Icon { get; private set; }
    public bool IsDefault { get; private set; }
    public Guid? UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Category() { }

    private Category(string name, string icon, bool isDefault, Guid? userId)
    {
        ValidateName(name);
        ValidateIcon(icon);

        if (!isDefault && !userId.HasValue)
            throw new DomainException(
                "Categorias personalizadas devem ter um usuário associado");

        if (isDefault && userId.HasValue)
            throw new DomainException(
                "Categorias padrão não podem ter usuário associado");

        Name = name;
        Icon = icon;
        IsDefault = isDefault;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    public static Category CreateDefault(string name, string icon)
    {
        return new Category(name, icon, true, null);
    }

    public static Category CreateCustom(string name, string icon, Guid userId)
    {
        if (userId == Guid.Empty)
            throw new DomainException("O ID do usuário não pode ser vazio");

        return new Category(name, icon, false, userId);
    }

    public void UpdateName(string newName)
    {
        if (IsDefault)
            throw new DomainException("Não é possível alterar nome de categoria padrão");

        if (DeletedAt.HasValue)
            throw new DomainException("Não é possível atualizar categoria excluída");

        ValidateName(newName);

        Name = newName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateIcon(string newIcon)
    {
        if (IsDefault)
            throw new DomainException("Não é possível alterar ícone de categoria padrão");

        if (DeletedAt.HasValue)
            throw new DomainException("Não é possível atualizar categoria excluída");

        ValidateIcon(newIcon);

        Icon = newIcon;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        if (IsDefault)
            throw new DomainException("Não é possível excluir categoria padrão");

        if (DeletedAt.HasValue)
            throw new DomainException("A categoria já foi excluída");

        DeletedAt = DateTime.UtcNow;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("O nome da categoria não pode ser vazio");

        if (name.Length < 2)
            throw new DomainException("O nome da categoria deve ter no mínimo 2 caracteres");

        if (name.Length > 50)
            throw new DomainException("O nome da categoria não pode exceder 50 caracteres");
    }

    private static void ValidateIcon(string icon)
    {
        if (string.IsNullOrWhiteSpace(icon))
            throw new DomainException("O ícone da categoria não pode ser vazio");

        if (icon.Length > 50)
            throw new DomainException("O ícone da categoria não pode exceder 50 caracteres");
    }
}