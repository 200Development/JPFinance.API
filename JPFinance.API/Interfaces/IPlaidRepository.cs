using JPFinance.API.Models;

namespace JPFinance.API.Interfaces
{
    public interface IPlaidRepository
    {

        /// <summary>
        /// Creates and returns a link token using Plaid's LinkTokenCreateAsync method.
        /// </summary>
        /// <returns>The generated link token as a string.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the response from Plaid does not contain a link token.</exception>
        Task<string> CreateLinkToken();


        /// <summary>
        /// Exchanges a public token for an access token using Plaid's ExchangePublicTokenAsync method.
        /// </summary>
        /// <param name="publicToken">The public token to be exchanged for an access token.</param>
        /// <returns>The access token corresponding to the provided public token, or null if the exchange was unsuccessful.</returns>
        Task<string?> ExchangePublicToken(PlaidPublicTokenExchangeRequest publicToken);
    }
}