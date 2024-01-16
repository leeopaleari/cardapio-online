using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardapioOnline.Application.DTOs;

public class CreateProductDto
{
    [Required(ErrorMessage = "O campo Código é obrigatório.")]
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(30, ErrorMessage = "Campo Nome deve ter, no máximo, 30 caracteres.")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [StringLength(30, ErrorMessage = "Campo Descrição deve ter, no máximo, 60 caracteres.")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O campo Valor Custo é obrigatório")]
    [JsonPropertyName("cost_value")]
    public decimal CostValue { get; set; }

    [Required(ErrorMessage = "O campo Valor Venda é obrigatório")]
    [JsonPropertyName("sell_value")]
    public decimal SellValue { get; set; }
}
