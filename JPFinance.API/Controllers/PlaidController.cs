using Microsoft.AspNetCore.Mvc;
using JPFinance.API.Interfaces;
using JPFinance.API.Models;
using JPFinance.API.Models.DTOs;

namespace JPFinance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaidController : Controller
    {
        private readonly IPlaidRepository _plaidRepo;
        private readonly IPennywiseRepository _pennywiseRepo;

        public PlaidController(IPlaidRepository plaidRepository, IPennywiseRepository pennywiseRepo)
        {
            _plaidRepo = plaidRepository;
            _pennywiseRepo = pennywiseRepo;
        }

        [HttpPost("linktokens")]
        public async Task<IActionResult> CreateLinkTokenAsync()
        {
            var linkToken = await _plaidRepo.CreateLinkToken();

            return Ok(new { linkToken });
        }

        [HttpPost("publictokenexchange")]
        public async Task<IActionResult> ExchangePublicToken([FromBody] PublicTokenMetadata metadata)
        {
            var request = new PlaidPublicTokenExchangeRequest()
            {
                PublicToken = metadata.PublicToken
            };

            var accessToken = await _plaidRepo.ExchangePublicToken(request);
            if (accessToken == null)
            {
                return Problem("Unable to exchange public token for access token", null, statusCode: 500);
            }

            //TODO: get userId
            var userId = 1;
            var accountDtos = metadata.Accounts.Select(account => new AccountDto { AccountId = account.AccountId, Name = account.Name, Type = account.Type, Subtype = account.Subtype }).ToList();

            var dto = new UpdateTokenAndSyncEntities
            {
                UserId = userId,
                AccessToken = accessToken,
                Institution = metadata.Institution,
                Accounts = accountDtos.ToArray()
            };
            // TODO: handle different responses
            await _pennywiseRepo.UpdateTokenAndSyncEntities(dto);

            return Ok();
        }
    }
}
