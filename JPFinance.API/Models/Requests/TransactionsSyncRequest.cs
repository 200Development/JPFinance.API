using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Requests;
using JPFinance.API.Models.Entities;

namespace JPFinance.API.Models.Requests;

/// <summary>
/// </summary>
/// <remarks>
/// See <see href="https://plaid.com/docs/api/products/transactions/#transactionssync">for more information</see>
/// </remarks>
public class TransactionsSyncRequest : ITransactionsSyncRequest
{
    [Required]
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("options")]
    public Options Options { get; set; } = new Options();
}