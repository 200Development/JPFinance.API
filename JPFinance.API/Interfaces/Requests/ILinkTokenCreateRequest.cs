using JPFinance.API.Interfaces.Entities;

namespace JPFinance.API.Interfaces.Requests;

public interface ILinkTokenCreateRequest
{
    IUser? User { get; set; }
    string? ClientName { get; set; }
    IList<string>? Products { get; set; }
}