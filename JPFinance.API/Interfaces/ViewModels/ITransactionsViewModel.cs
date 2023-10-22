using JPFinance.API.Models.Entities;

namespace JPFinance.API.Interfaces.ViewModels;

public interface ITransactionsViewModel
{
    public List<Added> AddedTransactions { get; set; }
    public List<Modified> ModifiedTransactions { get; set; }
}