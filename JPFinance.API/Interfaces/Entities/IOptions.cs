using System.Text.Json.Serialization;

namespace JPFinance.API.Interfaces.Entities;

public interface IOptions
{
    [JsonPropertyName("include_original_description")]
    bool IncludeOriginalDescription { get; set; }
}