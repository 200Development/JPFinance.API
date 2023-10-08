using JPFinance.API.Interfaces;
using JPFinance.API.Models;

namespace JPFinance.API.Services
{
    public class PlaidService : IPlaidService
    {
        private readonly HttpClient _client;

        public PlaidService(IHttpClientFactory clientFactory)
        {
            //_client = clientFactory.CreateClient("SandboxClient");
            _client = clientFactory.CreateClient("DevelopmentClient");
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
            var uri = _client.BaseAddress + "link/public_token/exchange";
            var response = await _client.PostAsJsonAsync(uri, request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PublicTokenExchangeResponse>();
        }
    }
}
