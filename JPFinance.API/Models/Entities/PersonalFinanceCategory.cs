using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Models.Entities;

public class PersonalFinanceCategory : IPersonalFinanceCategory
{
    [JsonPropertyName("primary")]
    public string Primary { get; set; } = string.Empty;

    [JsonPropertyName("detailed")] 
    public string Detailed { get; set; } = string.Empty;

    [JsonPropertyName("confidence_level")]
    public string? ConfidenceLevel { get; set; }

    [JsonPropertyName("transaction_code")]
    public string? TransactionCode { get; set; }

    [JsonPropertyName("personal_finance_category_icon_url")]
    public string PersonalFinanceCategoryIconUrl { get; set; } = string.Empty;

    [JsonPropertyName("counterparties")] 
    public CounterParties CounterParties { get; set; } = new CounterParties();
}