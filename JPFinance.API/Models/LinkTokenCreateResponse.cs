using System.Text.Json.Serialization;

/*******************************************************************
   
   Link to Plaid documentation explaining the structure of this model:
   https://plaid.com/docs/api/tokens/#linktokencreate
   returned in response from a successful call to Plaid endpoint /item/public_token/exchange.
   
*******************************************************************/

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
