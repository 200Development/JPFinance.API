using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Responses;

public interface ITransactionsSyncResponse
{
    List<Added> Added { get; set; }
    List<Modified> Modified { get; set; }
    List<Removed> Removed { get; set; }
    string NextCursor { get; set; }
    bool HasMore { get; set; }
    string RequestId { get; set; }
}