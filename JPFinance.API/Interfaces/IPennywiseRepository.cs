using JPFinance.API.Models;
using JPFinance.API.Models.ViewModels;

namespace JPFinance.API.Interfaces
{
    public interface IPennywiseRepository
    {
        /// <summary>
        /// Updates the token and synchronizes the entities based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="dto">An instance of UpdateTokenAndSyncEntities containing details for the update and synchronization.</param>
        /// <returns>True if the operation is successful; otherwise, false.</returns>
        public Task<bool> UpdateTokenAndSyncEntities(UpdateTokenAndSyncEntities dto);

        /// <summary>
        /// Retrieves a list of account view models associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user for whom the accounts are to be fetched.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of <see cref="AccountsViewModel"/> objects associated with the provided user.
        /// Returns null if no accounts are found or an error occurs.
        /// </returns>
        /// <remarks>
        /// This method queries the database view named 'vw_AllUserAccounts' using a parameterized query.
        /// It constructs a list of <see cref="AccountsViewModel"/> objects by reading from the database,
        /// converting database fields into appropriate model properties.
        /// Any potential DBNull values in the balance or limit fields are handled safely.
        /// </remarks>
        public Task<List<AccountsViewModel>?> GetAccountsViewModel(int userId);
    }
}
