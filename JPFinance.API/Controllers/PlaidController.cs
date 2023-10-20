using Microsoft.AspNetCore.Mvc;
using JPFinance.API.Interfaces;
using JPFinance.API.Models;

namespace JPFinance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaidController : Controller
    {
        private readonly IPlaidService _plaidService;

        public PlaidController(IPlaidService plaidService, IPennywiseRepository pennywiseRepo)
        {
            _plaidService = plaidService;
        }

        [HttpPost("linktokens")]
        public async Task<IActionResult> CreateLinkTokenAsync()
        {
            var linkToken = await _plaidService.CreateLinkToken();

            return Ok(new { linkToken });
        }

        [HttpPost("publictokenexchange")]
        public async Task<IActionResult> ExchangePublicToken([FromBody] PublicTokenMetadata metadata)
        {
            var accounts = await _plaidService.ExchangePublicToken(metadata);

            return accounts == null 
                ? Problem("Unable to exchange public token for access token", null, statusCode: 500)
                : Ok(accounts);
        }
    }
}
