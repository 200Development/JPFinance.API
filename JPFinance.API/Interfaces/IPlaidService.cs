using JPFinance.API.Models;
using JPFinance.API.Models.ViewModels;

namespace JPFinance.API.Interfaces
{
    public interface IPlaidService
    {
        public Task<string> CreateLinkToken();
        public Task<List<AccountViewModel>?> ExchangePublicToken(PublicTokenMetadata metadata);
    }
}
