using System.Security.Principal;
using System.Text.Json.Serialization;

namespace JPFinance.API.Models;

public class PublicTokenExchangeRequest
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("link_session_id")]
    public string LinkSessionId { get; set; }

    [JsonPropertyName("institution")]
    public Institution InstitutionInfo { get; set; }

    [JsonPropertyName("accounts")]
    public Account[] Accounts { get; set; }

    [JsonPropertyName("account")]
    public Account AccountInfo { get; set; }

    [JsonPropertyName("account_id")]
    public string AccountId { get; set; }

    [JsonPropertyName("transfer_status")]
    public string? TransferStatus { get; set; } // Assuming transfer_status can be any object type

    [JsonPropertyName("public_token")]
    public string PublicToken { get; set; }
}