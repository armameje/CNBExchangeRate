using ExchangeRateProvider.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateProvider.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CNBController : ControllerBase
    {
        private readonly ICNBHttpClient _cnbHttpClient;

        public CNBController(ICNBHttpClient cNBHttpClient)
        {
            _cnbHttpClient = cNBHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Today()
        {
            await _cnbHttpClient.GetExchangeRatesToday();

            return Ok();
        }
    }
}
