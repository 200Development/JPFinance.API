using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Entities;

public interface IAdded
{
    string AccountId { get; set; }
    double Amount { get; set; }
    string? IsoCurrencyCode { get; set; }
    string Date { get; set; }
    Location Location { get; set; }
    string Name { get; set; }
    string TransactionId { get; set; }
    string? AuthorizedDateTime { get; set; }
    Modified Modified { get; set; }
    Removed Removed { get; set; }
    string NextCursor { get; set; }
    bool HasMore { get; set; }
    string RequestId { get; set; }
}