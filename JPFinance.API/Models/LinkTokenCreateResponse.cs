using System.Text.Json.Serialization;

namespace JPFinance.API.Models
{
    public class LinkTokenCreateResponse
    {
        [JsonPropertyName("link_token")]
        public string? LinkToken { get; set; }
        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }
        [JsonPropertyName("request_id")]
        public string? RequestId { get; set; }
    }
}
