﻿using JPFinance.API.Interfaces;
using JPFinance.API.Models;
using JPFinance.API.Services;

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
    }
}