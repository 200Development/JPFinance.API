using JPFinance.API.Interfaces.Entities;
using JPFinance.API.Interfaces.ViewModels;

namespace JPFinance.API.Interfaces.Repositories;

public interface IPennywiseRepository
{
   public Task<bool> UpdateTokenAndSyncEntities(IUpdateTokenAndSyncEntities dto);

   public Task<IList<IAccountsViewModel>?> GetAccountsViewModel(int userId);
}