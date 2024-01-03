using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CardapioOnline.API.Models;

[Table("T_PRODUCT")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("id")]
    [Required(ErrorMessage = "O campo Código é obrigatório.")]
    public int Code { get; set; }

    [Column("nm_name")]
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Name { get; set; }

    [Column("ds_description")]
    public string? Description { get; set; }

    [Column("vl_cost_value")]
    [Precision(18, 2)]
    [Required(ErrorMessage = "O campo Valor Custo é obrigatório")]
    public decimal CostValue { get; set; }

    [Column("vl_sell_value")]
    [Precision(18, 2)]
    [Required(ErrorMessage = "O campo Valor Venda é obrigatório")]
    public decimal SellValue { get; set; }
}