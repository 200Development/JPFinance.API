using Microsoft.AspNetCore.Mvc;
using JPFinance.API.Interfaces;
using JPFinance.API.Models;

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
        public async Task<IActionResult> ExchangePublicToken([FromBody] PublicTokenExchangeRequest publicToken)
        {
            if (publicToken.PublicToken == null)
            {
                return Problem("Unable to exchange public token for access token", null, statusCode: 500);
            }

            var accessToken = await _plaidRepo.ExchangePublicToken(publicToken.PublicToken);
            if (accessToken == null)
            {
                return Problem("Unable to exchange public token for access token", null, statusCode: 500);
            }

            //TODO: get userId
            var userId = 1;

          //  var response = _pennywiseRepo.SaveAccessToken(userId,  .InstitutionId, institution.InstitutionName, accessToken);

            return Ok();
        }
    }
}
