using JPFinance.API.Models;

namespace JPFinance.API.Interfaces
{
    public interface IPlaidClient
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
        Task<PublicTokenExchangeResponse?> ExchangePublicTokenAsync(PublicTokenExchangeRequest request);

        /// <summary>
        /// Asynchronously retrieves an array of accounts with their balances from a specified endpoint.
        /// </summary>
        /// <param name="accessToken">The access token to be included in the request payload.</param>
        /// <returns>An array of accounts implementing the IAccount interface.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">Thrown if the response indicates a non-success status code.</exception>
        public Task<IList<IAccount>> GetAccountsAsync(string accessToken);
    }
}