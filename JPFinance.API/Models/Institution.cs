using System.Text.Json.Serialization;
using Newtonsoft.Json;

/*******************************************************************

 Link to Plaid documentation explaining the structure of this model:
 https://plaid.com/docs/link/web/#onsuccess
 returned in metadata object from a successful call to Plaid endpoint /link/token/create.

*******************************************************************/

namespace JPFinance.API.Models
{
    public class Institution
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("institution_id")]
        [JsonPropertyName("institution_id")]
        public string InstitutionId { get; set; } = string.Empty;
    }
}
