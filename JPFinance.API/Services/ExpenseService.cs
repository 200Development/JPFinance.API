using JPFinance.API.Interfaces;
using JPFinance.API.Models;

namespace JPFinance.API.Services
{
	public class ExpenseService
	{
		private readonly IPennywiseRepository _pennywiseRepo;

		public ExpenseService(IPennywiseRepository pennywiseRepository)
		{
			_pennywiseRepo = pennywiseRepository;
		}

		public async Task<List<RecurringTransaction>> GetPrePaydayExpenses(string userId)
		{
			return await _pennywiseRepo.GetPrePaydayExpenses(userId);
		}

		public async Task<List<RecurringTransaction>> GetPostPaydayExpenses(string userId)
		{
			return await _pennywiseRepo.GetPostPaydayExpenses(userId);
		}
	}
}

