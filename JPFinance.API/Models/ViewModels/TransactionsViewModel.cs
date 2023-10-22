using JPFinance.API.Interfaces.ViewModels;
using JPFinance.API.Models.Entities;

namespace JPFinance.API.Models.ViewModels;

public class TransactionsViewModel : ITransactionsViewModel
{
    public List<Added> AddedTransactions { get; set; } = new ();
    public List<Modified> ModifiedTransactions { get; set; } = new ();
}