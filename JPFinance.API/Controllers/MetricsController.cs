using JPFinance.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JPFinance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : Controller
    {
        private readonly IMetricService _metricService;

        public MetricsController(IMetricService metricService)
        {
            _metricService = metricService;
        }
        
       [HttpPost("savings")]
       public async Task<IActionResult> GetSavingsMetrics(string userId)
       {
            var metrics = await _metricService.GetSavingsMetrics(userId);

            return Ok(metrics);
       }
    }
}

