using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioOnline.API.Models;

public class Category
{
    [Key]
    [Column("id")]
    public string Id { get; set; }
    
    [Column("nm_category")]
    [Required]
    public string CategoryName { get; set; }
}