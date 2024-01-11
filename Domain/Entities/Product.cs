using CardapioOnline.Domain.Validations;

namespace CardapioOnline.Domain.Entities;

public class Product
{
    public int Code { get; private set; }
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public decimal CostValue { get; private set; }

    public decimal SellValue { get; private set; }

    // public int CategoryId { get; set; }
    // public Category Category { get; set; }

    public Product(int code, string name, string? description, decimal costValue, decimal sellValue)
    {
        Code = code;
        ValidateDomain(name, description, costValue, sellValue);
    }

    public void Update(string name, string? description, decimal costValue, decimal sellValue)
    {
        ValidateDomain(name, description, costValue, sellValue);
    }
    
    public void ValidateDomain(string name, string? description, decimal costValue, decimal sellValue)
    {
        DomainExceptionValidation.When(name.Length > 30, "Campo Nome deve ter, no máximo, 30 caracteres.");
        DomainExceptionValidation.When(description.Length > 60, "Campo Descrição deve ter, no máximo, 60 caracteres.");
        
        Name = name;
        Description = description;
        CostValue = costValue;
        SellValue = sellValue;
    }
}