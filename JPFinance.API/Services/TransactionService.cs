using JPFinance.API.Interfaces.Clients;
using JPFinance.API.Interfaces.DTOs;
using JPFinance.API.Interfaces.Repositories;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Interfaces.Services;
using JPFinance.API.Models.DTOs;
using JPFinance.API.Models.Requests;

namespace JPFinance.API.Services;

public class TransactionService : ITransactionService
{
    private readonly IPlaidClient _plaidClient;
    private readonly IPennywiseRepository _pennywiseRepo;

    public TransactionService(IPlaidClient plaidClient, IPennywiseRepository pennywiseRepository)
    {
        _plaidClient = plaidClient;
        _pennywiseRepo = pennywiseRepository;
    }

    public async Task<ITransactionsDTO?> GetTransactionsByItemIdAsync(int itemId)
    {
        try
        {
            var dto = new TransactionsDTO();
            var hasMore = true;
            var cursorAndToken = await _pennywiseRepo.GetAccessTokenAndLatestCursor(itemId);
           
            if (cursorAndToken == null)
            {
                return null;
            }

            var request = new TransactionsSyncRequest();
            request.AccessToken = cursorAndToken.AccessToken;
            request.Cursor = cursorAndToken.NextCursor ?? string.Empty;
            request.Count = 100;
            while(hasMore)
            {
                ITransactionsSyncResponse? response = await _plaidClient.GetTransactionsAsync(request);

                if(response == null || (!response.Added.Any() && !response.Modified.Any() && !response.Removed.Any()))
                {
                    return null;
                }

                foreach(var addedTransaction in response.Added)
                {
                    var added = new TransactionDTO();
                    added.AccountId = addedTransaction.AccountId;
                    added.Amount = addedTransaction.Amount;
                    added.IsoCurrencyCode = addedTransaction.IsoCurrencyCode;
                    added.Date = addedTransaction.Date;
                    added.Name = addedTransaction.Name;
                    added.MerchantName = addedTransaction.MerchantName;
                    added.OriginalDescription = addedTransaction.OriginalDescription;
                    added.Payee = addedTransaction.PaymentMeta.Payee;
                    added.Payer = addedTransaction.PaymentMeta.Payer;
                    added.PaymentMethod = addedTransaction.PaymentMeta.PaymentMethod;
                    added.PendingTransactionId = addedTransaction.PendingTransactionId;
                    added.TransactionId = addedTransaction.TransactionId;
                    added.LogoUrl = addedTransaction.LogoUrl;
                    added.Website = addedTransaction.Website;
                    added.AuthorizedDateTime = addedTransaction.AuthorizedDateTime;
                    dto.AddedTransactions.Add(added);
                }

                foreach(var modifiedTransaction in response.Modified)
                {
                    var modified = new TransactionDTO();
                    modified.AccountId = modifiedTransaction.Id;
                    modified.Amount = modifiedTransaction.Amount;
                    modified.IsoCurrencyCode = modifiedTransaction.IsoCurrencyCode;
                    modified.Date = modifiedTransaction.Date;
                    modified.MerchantName = modifiedTransaction.MerchantName;
                    modified.OriginalDescription = modifiedTransaction.OriginalDescription;
                    modified.Payee = modifiedTransaction.PaymentMeta.Payee;
                    modified.Payer = modifiedTransaction.PaymentMeta.Payer;
                    modified.PaymentMethod = modifiedTransaction.PaymentMeta.PaymentMethod;
                    modified.PendingTransactionId = modifiedTransaction.PendingTransactionId;
                    modified.TransactionId = modifiedTransaction.TransactionId;
                    modified.LogoUrl = modifiedTransaction.LogoUrl;
                    modified.Website = modifiedTransaction.Website;
                    modified.AuthorizedDateTime = modifiedTransaction.AuthorizedDateTime;
                    dto.ModifiedTransactions.Add(modified);
                }

                foreach (var removedTransaction in response.Removed)
                {
                    var removed = new TransactionDTO();
                    removed.TransactionId = removedTransaction.TransactionId;
                    dto.RemovedTransactions.Add(removed);
                }

                hasMore = response.HasMore;
                request.Cursor = response.NextCursor;
            }
            dto.NextCursor = request.Cursor;

            //TODO: temp for testing sync transactions.  need to modify how account id is handled
            dto.AccountId = "KbqnZbJAQjid161xr1Aziw7zVBa6evtRV6XWm";

            await _pennywiseRepo.SyncTransactionsForItem(dto);
            
            return dto;
        }
        catch(Exception e)
        {
            return null;
        }
    }
}