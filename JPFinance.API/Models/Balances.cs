using System.Text.Json.Serialization;

namespace JPFinance.API.Models
{
    public class Balances
    {
        [JsonPropertyName("available")]
        public decimal? Available { get; set; }

        [JsonPropertyName("current")]
        public decimal? Current { get; set; }

        [JsonPropertyName("iso_currency_code")]
        public string? IsoCurrencyCode { get; set; }

        [JsonPropertyName("limit")]
        public decimal? Limit { get; set; }

        [JsonPropertyName("unofficial_currency_code")]
        public string? UnofficialCurrencyCode { get; set; }

        [JsonPropertyName("last_updated_date")]
        public string? LastUpdatedDate { get; set; }
    }
}
