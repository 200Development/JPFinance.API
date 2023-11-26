using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Models.Entities;

namespace JPFinance.API.Models.Responses;

public class TransactionsSyncResponse : ITransactionsSyncResponse
{
    [JsonPropertyName("added")]
    public List<Added> Added { get; set; } = new();

    [JsonPropertyName("modified")]
    public List<Modified> Modified { get; set; } = new();

    [JsonPropertyName("removed")]
    public List<Removed> Removed { get; set; } = new();

    [JsonPropertyName("next_cursor")]
    public string NextCursor { get; set; } = string.Empty;

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; } = false;

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;
}