using JPFinance.API.Models;

namespace JPFinance.API.Services
{
	public class MetricService
	{
		private readonly AccountService _accountService;
		private readonly ExpenseService _expenseService;

        public MetricService(AccountService accountService, ExpenseService expenseService)
		{
			_accountService = accountService;
			_expenseService = expenseService;
		}

		public async Task<SavingsMetrics> GetSavingsMetrics(string userId)
		{
			var metrics = new SavingsMetrics();
			var accounts = await _accountService.GetAccounts(userId);
			var expensesDueBeforeNextPayday = await _expenseService.GetPrePaydayExpenses(userId); 

			foreach (var account in accounts)
			{
				metrics.TotalCash += account.AvailableBalance;
			}

			var totalExpensesDueBeforePayday = 0.0m;
			foreach(var expense in expensesDueBeforeNextPayday)
			{
				totalExpensesDueBeforePayday += expense.AverageAmount;
			}
			metrics.CashLeftUntilPayday = metrics.TotalCash - totalExpensesDueBeforePayday;

			return metrics;
		}
	}
}

