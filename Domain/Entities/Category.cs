
using CardapioOnline.Domain.Validations;

namespace CardapioOnline.Domain.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ICollection<Product> Products { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        ValidateDomain(name);
    }

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(name.Length > 30, "Campo Nome Categoria deve ter, no máximo, 30 caracteres.");
        Name = name;
    }
}