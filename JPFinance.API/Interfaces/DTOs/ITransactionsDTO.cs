using JPFinance.API.Models.DTOs;

namespace JPFinance.API.Interfaces.DTOs;

public interface ITransactionsDTO
{
    public List<TransactionDTO> AddedTransactions { get; set; }
    public List<TransactionDTO> ModifiedTransactions { get; set; }
    public List<TransactionDTO> RemovedTransactions { get; set; }
    public string? NextCursor { get; set; }
    public string? AccountId { get; set; }
}