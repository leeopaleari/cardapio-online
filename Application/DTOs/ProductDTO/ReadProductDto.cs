using System.Text.Json.Serialization;

namespace CardapioOnline.Application.DTOs;

public class ReadProductDto
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("cost_value")]
    public decimal CostValue { get; set; }

    [JsonPropertyName("sell_value")]
    public decimal SellValue { get; set; }
}