using JPFinance.API.Models;

namespace JPFinance.API.Interfaces
{
    public interface IPlaidService
    {
        /// <summary>
        /// Creates a link token for initiating a Plaid Link session.
        /// </summary>
        /// <param name="request">The request object containing necessary parameters to create a link token.</param>
        /// <returns>An asynchronous operation that returns a response containing the link token, or null if the operation fails.</returns>
        Task<LinkTokenCreateResponse?> LinkTokenCreateAsync(LinkTokenCreateRequest request);

        /// <summary>
        /// Exchanges a public token for an access token.
        /// </summary>
        /// <param name="request">The request object containing the public token to be exchanged.</param>
        /// <returns>An asynchronous operation that returns a response containing the access token, or null if the operation fails.</returns>
        Task<PublicTokenExchangeResponse?> ExchangePublicTokenAsync(PlaidPublicTokenExchangeRequest request);
    }
}