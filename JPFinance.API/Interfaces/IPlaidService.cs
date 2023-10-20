using JPFinance.API.Models;
using JPFinance.API.Models.ViewModels;

namespace JPFinance.API.Interfaces
{
    public interface IPlaidService
    {
        public Task<string> CreateLinkToken();
        public Task<List<AccountsViewModel>?> ExchangePublicToken(PublicTokenMetadata metadata);
    }
}
