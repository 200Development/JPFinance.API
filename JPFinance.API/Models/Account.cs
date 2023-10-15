using System.Text.Json.Serialization;

/*******************************************************************

 Link to Plaid documentation explaining the structure of this model:
 https://plaid.com/docs/link/web/#onsuccess
 returned in metadata object from a successful call to Plaid endpoint /link/token/create.

*******************************************************************/

namespace JPFinance.API.Models
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string AccountId { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("mask")]
        public string Mask { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("subtype")]
        public string Subtype { get; set; } = string.Empty;

        [JsonPropertyName("verification_status")]
        public string? VerificationStatus { get; set; }

        [JsonPropertyName("class_type")]
        public string? ClassType { get; set; }
    }
}
