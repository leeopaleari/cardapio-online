namespace CardapioOnline.Application.DTOs;

public class UpdateProductDto
{
    public int Code { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public decimal CostValue { get; set; }

    public decimal SellValue { get; set; }
}