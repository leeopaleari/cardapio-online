using System.ComponentModel.DataAnnotations;

namespace CardapioOnline.API;

public class CreateProductDto
{
    [Required(ErrorMessage = "O campo Código é obrigatório.")]
    public int Code { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "O campo Valor Custo é obrigatório")]
    public decimal CostValue { get; set; }

    [Required(ErrorMessage = "O campo Valor Venda é obrigatório")]
    public decimal SellValue { get; set; }
}
