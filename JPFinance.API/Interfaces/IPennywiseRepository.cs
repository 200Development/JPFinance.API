using JPFinance.API.Models;

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
    }
}
