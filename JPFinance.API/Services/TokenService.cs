﻿using JPFinance.API.Interfaces.Clients;
using JPFinance.API.Interfaces.Entities;
using JPFinance.API.Interfaces.Repositories;
using JPFinance.API.Interfaces.Services;
using JPFinance.API.Interfaces.ViewModels;
using JPFinance.API.Models.DTOs;
using JPFinance.API.Models.Entities;
using JPFinance.API.Models.Requests;

namespace JPFinance.API.Services;

public class TokenService : ITokenService
{
    private readonly IPlaidClient _plaidClient;
    private readonly IPennywiseRepository _pennywiseRepo;

    public TokenService(IPlaidClient plaidClient, IPennywiseRepository pennywiseRepo)
    {
        _pennywiseRepo = pennywiseRepo;
        _plaidClient = plaidClient;
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
            var response = await _plaidClient.LinkTokenCreateAsync(request);
            return response?.LinkToken ?? throw new InvalidOperationException("Response does not contain a link token.");
        }
        catch(Exception error)
        {
            throw;
        }
    }
        
    public async Task<IList<IAccountsViewModel>?> ExchangePublicToken(IPublicTokenMetadata metadata)
    {
        var request = new PublicTokenExchangeRequest()
        {
            PublicToken = metadata.PublicToken
        };

        // Exchange public token for access token
        var accessToken = await _plaidClient.ExchangePublicTokenAsync(request);
        if(accessToken == null || accessToken.AccessToken == string.Empty) { return null; }

        // Use access token to get real-time data for accounts tied to access token (item)
        var accounts = await _plaidClient.GetAccountsAsync(new GetAccountsRequest(accessToken.AccessToken));
        if (accounts == null) { return null; }

        var userId = 1;
        var accountDtos = new List<AccountDto>();

        foreach (var account in accounts.Accounts)
        {
            var newAccountDto = new AccountDto();
            newAccountDto.AccountId = account.AccountId;
            newAccountDto.Name = account.Name;
            newAccountDto.Type = account.Type;
            newAccountDto.Subtype = account.Subtype;
            newAccountDto.AvailableBalance = account.Balances?.Available;
            newAccountDto.CurrentBalance = account.Balances?.Current;
            newAccountDto.Limit = account.Balances?.Limit;
            newAccountDto.IsoCurrencyCode = account.Balances?.IsoCurrencyCode;
            accountDtos.Add(newAccountDto);
        }
            
        var dto = new UpdateTokenAndSyncEntities
        {
            UserId = userId,
            AccessToken = accessToken.AccessToken,
            Institution = metadata.Institution,
            Accounts = accountDtos
        };
            
        // TODO: handle different responses
        // Save access token and item entities to database
        try
        {
            var saveSuccessful = await _pennywiseRepo.UpdateTokenAndSyncEntities(dto);
            if (!saveSuccessful) { return null; }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        if (!accounts.Accounts.Any())
        {
            return new List<IAccountsViewModel>();
        }
        try
        {
            return await _pennywiseRepo.GetAccountsViewModel(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}