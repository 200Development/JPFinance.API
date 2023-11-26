using JPFinance.API.Interfaces;
using JPFinance.API.Models.ViewModels;

namespace JPFinance.API.Services
{
	public class AccountService
	{
		private readonly IPennywiseRepository _pennywiseRepo;

		public AccountService(IPennywiseRepository pennywiseRepository)
		{
			_pennywiseRepo = pennywiseRepository;
		}

		public async Task<List<AccountViewModel>> GetAccounts(string userId) {
			if (string.IsNullOrWhiteSpace(userId)) return new List<AccountViewModel>();

            return await _pennywiseRepo.GetAccountsViewModel(userId);
		}
	}
}

