using System.Text.Json.Serialization;

namespace JPFinance.API.Models.DTOs
{
    public class AccountDto
    {
        [JsonPropertyName("id")] public string AccountId { get; set; } = string.Empty;

        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

        [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

        [JsonPropertyName("subtype")] public string Subtype { get; set; } = string.Empty;
    }
}