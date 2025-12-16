using ExchangeRateProvider.Domain.Common;
using ExchangeRateProvider.Domain.Options;
using ExchangeRateProvider.Domain.Services;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

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

        public async Task GetExchangeRatesToday()
        {
            try
            {
                var response = await _httpClient.GetAsync("exrates/daily?lang=EN").ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<Rates>().ConfigureAwait(false);

            }
            catch (Exception e)
            {
                var x = e;
            }
        }
    }
}
