using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Models.Entities
{
    public class Options : IOptions
    {
        [JsonPropertyName("include_original_description")]
        public bool IncludeOriginalDescription { get; set; }
    }
}
