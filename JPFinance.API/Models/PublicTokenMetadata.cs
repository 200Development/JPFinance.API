using System.Text.Json.Serialization;

/*******************************************************************
 
 Link to Plaid documentation explaining the structure of this model:
 https://plaid.com/docs/link/web/#onsuccess

*******************************************************************/

namespace JPFinance.API.Models
{
    public class PublicTokenMetadata
    {
        [JsonPropertyName("public_token")] public string PublicToken { get; set; } = string.Empty;

        [JsonPropertyName("institution")] public Institution Institution { get; set; } = new();

        [JsonPropertyName("accounts")] public Account[] Accounts { get; set; } = Array.Empty<Account>();

        [Obsolete("Deprecated. Use accounts instead.  https://plaid.com/docs/link/web/#onsuccess")]
        [JsonPropertyName("account")]
        public Account? Account { get; set; }

        [JsonPropertyName("link_session_id")] public string LinkSessionId { get; set; } = string.Empty;

        [JsonPropertyName("transfer_status")] public string? TransferStatus { get; set; }
    }
}