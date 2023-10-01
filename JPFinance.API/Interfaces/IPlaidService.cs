using JPFinance.API.Models;

namespace JPFinance.API.Interfaces;

public interface IPlaidService
{
    Task<LinkTokenCreateResponse?> LinkTokenCreateAsync(LinkTokenCreateRequest request);
}