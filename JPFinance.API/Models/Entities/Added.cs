using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Models.Entities;

public class Added : IAdded
{
    [JsonPropertyName("account_id")] public string AccountId { get; set; } = string.Empty;

    [JsonPropertyName("amount")] public double Amount { get; set; }

    [JsonPropertyName("iso_currency_code")]
    public string? IsoCurrencyCode { get; set; }

    [JsonPropertyName("unofficial_currency_code")]
    public string? UnofficialCurrencyCode { get; set; }

    [Obsolete("deprecated")]
    [JsonIgnore]
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [Obsolete("deprecated")]
    [JsonIgnore]
    [JsonPropertyName("category_id")]
    public string? CategoryId { get; set; }

    [JsonPropertyName("check_number")] public string? CheckNumber { get; set; }

    [JsonPropertyName("date")] public string Date { get; set; } = string.Empty;

    [JsonPropertyName("location")] public Location Location { get; set; } = new ();

    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

    [JsonPropertyName("merchant_name")] public string? MerchantName { get; set; }

    [JsonPropertyName("original_description")]
    public string? OriginalDescription { get; set; }

    [JsonPropertyName("payment_meta")] public PaymentMeta PaymentMeta { get; set; } = new ();

    [JsonPropertyName("pending")] public bool Pending { get; set; }

    [JsonPropertyName("pending_transaction_id")]
    public string? PendingTransactionId { get; set; }

    [JsonPropertyName("account_owner")] public string? AccountOwner { get; set; }

    [JsonPropertyName("transaction_id")] public string TransactionId { get; set; } = string.Empty;

    [Obsolete("deprecated")]
    [JsonIgnore]
    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; set; }

    [JsonPropertyName("logo_url")] public string? LogoUrl { get; set; }

    [JsonPropertyName("website")] public string? Website { get; set; }

    [JsonPropertyName("authorized_date")] public string? AuthorizedDate { get; set; }

    [JsonPropertyName("authorized_datetime")]
    public string? AuthorizedDateTime { get; set; }

    [JsonPropertyName("datetime")] public string? DateTime { get; set; }

    [JsonPropertyName("payment_channel")] public string PaymentChannel { get; set; } = string.Empty;

    [JsonPropertyName("personal_finance_category")]
    public PersonalFinanceCategory PersonalFinanceCategory { get; set; } = new ();

    [JsonPropertyName("transaction_code")] public string? TransactionCode { get; set; }

    [JsonPropertyName("personal_finance_category_icon_url")]
    public string PersonalFinanceCategoryIconUrl { get; set; } = string.Empty;

    [JsonPropertyName("counterparties")] public List<CounterParties> CounterParties { get; set; } = new ();

    [JsonPropertyName("merchant_entity_id")]
    public string? MerchantEntityId { get; set; }
}