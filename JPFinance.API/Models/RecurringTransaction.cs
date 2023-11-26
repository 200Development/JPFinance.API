namespace JPFinance.API.Models
{
	public class RecurringTransaction
	{
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Frequency { get; set; } = string.Empty;
		public string StartDate { get; set; } = string.Empty;
		public string LastDate { get; set; } = string.Empty;
		public decimal LastAmount { get; set; }
		public decimal AverageAmount { get; set; }
	}
}

