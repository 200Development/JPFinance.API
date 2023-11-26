using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.Responses;

public interface IGetAccountsResponse
{
    List<Account> Accounts { get; set; }
    Item Item { get; set; }
    string RequestId { get; set; }
}