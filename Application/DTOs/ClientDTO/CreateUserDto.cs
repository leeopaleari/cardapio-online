using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardapioOnline.Application.DTOs.ClientDTO;

public class CreateUserDto
{
    [Required]
    [StringLength(15)]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}