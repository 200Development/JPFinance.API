using System.Text.Json.Serialization;

namespace JPFinance.API.Models;

public class PublicTokenExchangeResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("item_id")]
    public string ItemId { get; set; }
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; }
}