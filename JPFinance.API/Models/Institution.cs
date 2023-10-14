using System.Text.Json.Serialization;

namespace JPFinance.API.Models
{
    public class Institution
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("institution_id")]
        public string InstitutionId { get; set; }
    }
}
