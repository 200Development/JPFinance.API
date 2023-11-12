﻿using JPFinance.API.Interfaces.DTOs;

namespace JPFinance.API.Models.DTOs;

public class TransactionsDTO : ITransactionsDTO
{
    public List<TransactionDTO> AddedTransactions { get; set; } = new();
    public List<TransactionDTO> ModifiedTransactions { get; set; } = new();
    public List<TransactionDTO> RemovedTransactions { get; set; } = new();
    public string? NextCursor { get; set; }
    public string? AccountId { get; set;}

}