using ExchangeRateProvider.Domain.Options;
using ExchangeRateProvider.Domain.Services;
using Microsoft.Extensions.Options;

namespace ExchangeRateProvider.Service.Services
{
    public class CNBHttpClient : ICNBHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly CNBOptions _options;

        public CNBHttpClient(HttpClient httpClient, IOptions<CNBOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;

            _httpClient.BaseAddress = new Uri(_options.Uri);
        }

        public Task GetExchangeRatesToday()
        {
            throw new NotImplementedException();
        }
    }
}
