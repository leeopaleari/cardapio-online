using System.ComponentModel.DataAnnotations;

namespace CardapioOnline.Application.DTOs;

public class CreateProductDto
{
    [Required(ErrorMessage = "O campo Código é obrigatório.")]
    public int Code { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(30, ErrorMessage = "Campo Nome deve ter, no máximo, 30 caracteres.")]
    public string Name { get; set; }

    [StringLength(30, ErrorMessage = "Campo Descrição deve ter, no máximo, 60 caracteres.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O campo Valor Custo é obrigatório")]
    public decimal CostValue { get; set; }

    [Required(ErrorMessage = "O campo Valor Venda é obrigatório")]
    public decimal SellValue { get; set; }
}
