using JPFinance.API.Interfaces;
using JPFinance.API.Models;

namespace JPFinance.API.Clients
{
    // TODO: Should PlaidRepository absorb PlaidClient?
    public class PlaidClient : IPlaidClient
    {
        private readonly HttpClient _client;

        public PlaidClient(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("SandboxClient");
            //_client = clientFactory.CreateClient("DevelopmentClient");
        }

        public async Task<LinkTokenCreateResponse?> LinkTokenCreateAsync(LinkTokenCreateRequest request)
        {
            var uri = _client.BaseAddress + "link/token/create";
            var response = await _client.PostAsJsonAsync(uri, request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<LinkTokenCreateResponse>();
        }

        public async Task<PublicTokenExchangeResponse?> ExchangePublicTokenAsync(PublicTokenExchangeRequest request)
        {
            var uri = _client.BaseAddress + "item/public_token/exchange";
            var response = await _client.PostAsJsonAsync(uri, request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PublicTokenExchangeResponse>();
        }

        public async Task<IList<IAccount>> GetAccountsAsync(string accessToken)
        {
            var uri = _client.BaseAddress + "accounts/balance/get";
            var request = new
            {
                access_token = accessToken
            };
            var responseJson = await _client.PostAsJsonAsync(uri, request);

            responseJson.EnsureSuccessStatusCode();

            try
            {
                var response = await responseJson.Content.ReadFromJsonAsync<GetAccountsResponse>();
                return response?.Accounts.Cast<IAccount>().ToList() ?? new List<IAccount>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
