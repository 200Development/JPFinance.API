using System.Text.Json.Serialization;
using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Models.Entities;

public class Removed : IRemoved
{
    [JsonPropertyName("transaction_id")] 
    public string TransactionId { get; set; } = string.Empty;
}