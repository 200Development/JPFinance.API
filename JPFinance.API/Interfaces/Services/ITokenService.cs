using JPFinance.API.Interfaces.Entities;
using JPFinance.API.Interfaces.ViewModels;

namespace JPFinance.API.Interfaces.Services;

public interface ITokenService
{
    public Task<string> CreateLinkToken();
    public Task<IList<IAccountsViewModel>?> ExchangePublicToken(IPublicTokenMetadata metadata);
}