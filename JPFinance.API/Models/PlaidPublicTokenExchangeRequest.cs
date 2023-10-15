using System.Text.Json.Serialization;

/*******************************************************************

 Link to Plaid documentation explaining the structure of this model:
 https://plaid.com/docs/api/tokens/#itempublic_tokenexchange
 request for call to Plaid endpoint /item/public_token/exchange.  

*******************************************************************/

namespace JPFinance.API.Models
{
    public class PlaidPublicTokenExchangeRequest
    {
        [JsonPropertyName("public_token")]
        public string PublicToken { get; set; } = string.Empty;
    }
}
