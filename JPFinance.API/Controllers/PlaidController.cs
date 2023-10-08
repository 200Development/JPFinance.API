using Microsoft.AspNetCore.Mvc;
using JPFinance.API.Interfaces;

namespace JPFinance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaidController : Controller
    {
        private readonly IPlaidRepository _plaidRepo;

        public PlaidController(IPlaidRepository plaidRepository)
        {
            _plaidRepo = plaidRepository;
        }

        [HttpPost("linktokens")]
        public async Task<IActionResult> CreateLinkTokenAsync()
        {
            var linkToken = await _plaidRepo.CreateLinkToken();

            return Ok(new { linkToken });
        }

        [HttpPost("publictokenexchange")]
        public async Task<IActionResult> ExchangePublicToken(string linkToken)
        {
            await _plaidRepo.ExchangePublicToken(linkToken);

            return Ok();
        }
    }
}
