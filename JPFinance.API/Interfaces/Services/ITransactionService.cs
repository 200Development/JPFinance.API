using JPFinance.API.Interfaces.ViewModels;
using JPFinance.API.Models.Requests;

namespace JPFinance.API.Interfaces.Services;

public interface ITransactionService
{
    Task<ITransactionsViewModel?> GetTransactionsAsync(TransactionsSyncRequest request);
}