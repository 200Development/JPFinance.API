using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Models.Entities;

namespace JPFinance.API.Models.Responses;

public class GetAccountsResponse : IGetAccountsResponse
{
    [JsonPropertyName("accounts")]
    public List<Account> Accounts { get; set; } = new ();

    [JsonPropertyName("item")]
    public Item Item { get; set; } = new ();

    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;
}