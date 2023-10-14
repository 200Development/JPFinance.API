﻿using JPFinance.API.Interfaces;
using JPFinance.API.Models;

namespace JPFinance.API.Repositories
{
    public class PlaidRepository : IPlaidRepository
    {
        private readonly IPlaidService _plaid;

        public PlaidRepository(IPlaidService plaidService)
        {
            _plaid = plaidService;
        }

        public async Task<string> CreateLinkToken()
        {
            var request = new LinkTokenCreateRequest
            {
                User = new User
                {
                    ClientUserId = "user-id",
                },
                ClientName = "JP Financial",
                Products = new List<string> { "transactions" },
                CountryCodes = new List<string> { "US" },
                Language = "en"
            };

            try
            {
                var response = await _plaid.LinkTokenCreateAsync(request);
                return response?.LinkToken ?? throw new InvalidOperationException("Response does not contain a link token.");
            }
            catch (Exception error)
            {
                throw;
            }
        }

        public async Task<string?> ExchangePublicToken(string publicToken)
        {
            var request = new PublicTokenExchangeRequest
            {
                PublicToken = publicToken
            };
            
            try
            {
                var response = await _plaid.ExchangePublicTokenAsync(request);
                return response?.AccessToken;
            }
            catch (Exception error)
            {
                throw;
            }
        }
    }
}
