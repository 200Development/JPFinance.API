using System.Text.Json.Serialization;

namespace JPFinance.API.Models
{
    public class GetAccountsResponse
    {
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; } = new List<Account>();

        [JsonPropertyName("item")]
        public Item Item { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = string.Empty;
    }
}
