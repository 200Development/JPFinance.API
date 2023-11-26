using JPFinance.API.Interfaces.DTOs;
using JPFinance.API.Interfaces.Entities;
using JPFinance.API.Interfaces.Responses;
using JPFinance.API.Interfaces.ViewModels;

namespace JPFinance.API.Interfaces.Repositories;

public interface IPennywiseRepository
{
   public Task<bool> UpdateTokenAndSyncEntities(IUpdateTokenAndSyncEntities dto);

   public Task<IList<IAccountsViewModel>?> GetAccountsViewModel(int userId);
    public Task<IGetAccessTokenAndLatestCursorResponse?> GetAccessTokenAndLatestCursor(int itemId);
    public Task<bool> SyncTransactionsForItem(ITransactionsDTO dto);
}