using System.Text.Json.Serialization;

namespace JPFinance.API.Models;

public class PlaidError
{
    [JsonPropertyName("error_type")] 
    public string ErrorType { get; set; } = string.Empty;

    [JsonPropertyName("error_code")]
    public string ErrorCode { get; set; } = string.Empty;

    [JsonPropertyName("error_message")]
    public string ErrorMessage { get; set; } = string.Empty;

    [JsonPropertyName("display_message")]
    public string? DisplayMessage { get; set; } = string.Empty;

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;

    [JsonPropertyName("causes")] 
    public PlaidError[] Causes { get; set; } = Array.Empty<PlaidError>();

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("documentation_url")]
    public string DocumentationUrl { get; set; } = string.Empty;

    [JsonPropertyName("suggested_action")]
    public string? SuggestedAction { get; set; }
}