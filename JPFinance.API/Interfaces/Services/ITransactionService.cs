using JPFinance.API.Interfaces.DTOs;

namespace JPFinance.API.Interfaces.Services;

public interface ITransactionService
{
    Task<ITransactionsDTO?> GetTransactionsByItemIdAsync(int itemId);
}