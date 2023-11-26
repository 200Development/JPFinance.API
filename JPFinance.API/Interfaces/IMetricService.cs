using JPFinance.API.Models;

namespace JPFinance.API.Interfaces
{
	public interface IMetricService
	{
        public Task<SavingsMetrics> GetSavingsMetrics(string userId);
    }
}

