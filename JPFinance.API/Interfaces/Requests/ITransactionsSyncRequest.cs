using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Requests;

public interface ITransactionsSyncRequest
{
    string AccessToken { get; set; }
    string Cursor { get; set; }
    int Count { get; set; }
    Options Options { get; set; }
}