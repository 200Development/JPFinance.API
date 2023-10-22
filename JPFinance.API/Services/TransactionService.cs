using JPFinance.API.Interfaces.Clients;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Interfaces.Services;
using JPFinance.API.Interfaces.ViewModels;
using JPFinance.API.Models.Entities;
using JPFinance.API.Models.Requests;
using JPFinance.API.Models.ViewModels;

namespace JPFinance.API.Services;

public class TransactionService : ITransactionService
{
    private readonly IPlaidClient _plaidClient;

    public TransactionService(IPlaidClient plaidClient)
    {
        _plaidClient = plaidClient;
    }

    public async Task<ITransactionsViewModel?> GetTransactionsAsync(TransactionsSyncRequest request)
    {
        try
        {
            ITransactionsSyncResponse? transactionsSyncResponse = await _plaidClient.GetTransactionsAsync(request);

            if (transactionsSyncResponse == null || !transactionsSyncResponse.Added.Any())
            {
                return null;
            }

            var viewModel = new TransactionsViewModel();
               
            foreach (var addedTransaction in transactionsSyncResponse.Added)
            {
                var added = new Added();
                added.AccountId = addedTransaction.AccountId;
                added.Amount = addedTransaction.Amount;
                added.IsoCurrencyCode = addedTransaction.IsoCurrencyCode;
                added.Date = addedTransaction.Date;
                added.Location = addedTransaction.Location;
                added.Name = addedTransaction.Name;
                added.TransactionId = addedTransaction.TransactionId;
                added.AuthorizedDateTime = addedTransaction.AuthorizedDateTime;
                added.Modified = addedTransaction.Modified;
                added.Removed = addedTransaction.Removed;
                added.NextCursor = addedTransaction.NextCursor;
                added.HasMore = addedTransaction.HasMore;
                added.RequestId = addedTransaction.RequestId;
                viewModel.AddedTransactions.Add(added);
            }

            foreach (var modifiedTransaction in transactionsSyncResponse.Modified)
            {
                var modified = new Modified();
                modified.Id = modifiedTransaction.Id;
                modified.Amount = modifiedTransaction.Amount;
                modified.IsoCurrencyCode = modifiedTransaction.IsoCurrencyCode;
                modified.CategoryId = modifiedTransaction.CategoryId;
                modified.Date = modifiedTransaction.Date;
                modified.Location = modifiedTransaction.Location;
                modified.TransactionId = modifiedTransaction.TransactionId;
                viewModel.ModifiedTransactions.Add(modified);
            }

            return viewModel;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}