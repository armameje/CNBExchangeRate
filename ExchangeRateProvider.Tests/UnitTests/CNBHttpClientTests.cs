using ExchangeRateProvider.Domain.Common;
using ExchangeRateProvider.Domain.Options;
using ExchangeRateProvider.Domain.Services;
using ExchangeRateProvider.Service.Services;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net.Http.Json;

namespace ExchangeRateProvider.Tests.UnitTests
{
    public class CNBHttpClientTests
    {
        private readonly IOptions<CNBOptions> _options;

        public CNBHttpClientTests()
        {
            _options = Options.Create<CNBOptions>(new CNBOptions { Uri = "https://test.com" });
        }

        [Fact]
        public async Task GetExchangeRatesToday_Success_TotalRatesIsFour()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = JsonContent.Create(new
                {
                    rates = new List<Rate>
                {
                    new Rate("2025-12-19", 246, "Australia", "dollar", 1, "AUD", 13.718M),
                    new Rate("2025-12-19", 246, "Canada", "dollar", 1, "CAD", 15.061M),
                    new Rate("2025-12-19", 246, "China", "renminbi", 1, "CNY", 2.951M),
                    new Rate("2025-12-19", 246, "South Korea", "won", 100, "KRW", 1.405M)
                }
                })
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://test.com")
            };

            ICNBHttpClient cnbHttpClient = new CNBHttpClient(httpClient, _options);

            var result = await cnbHttpClient.GetExchangeRatesToday();

            Assert.True(result.rates.Count.Equals(4));
        }

        [Fact]
        public async Task GetExchangeRatesToday_Success_AustraliaRateIsAvailable()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = JsonContent.Create(new
                {
                    rates = new List<Rate>
                {
                    new Rate("2025-12-19", 246, "Australia", "dollar", 1, "AUD", 13.718M),
                    new Rate("2025-12-19", 246, "Canada", "dollar", 1, "CAD", 15.061M),
                    new Rate("2025-12-19", 246, "China", "renminbi", 1, "CNY", 2.951M),
                    new Rate("2025-12-19", 246, "South Korea", "won", 100, "KRW", 1.405M)
                }
                })
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://test.com")
            };

            ICNBHttpClient cnbHttpClient = new CNBHttpClient(httpClient, _options);

            var result = await cnbHttpClient.GetExchangeRatesToday();

            Assert.Contains(result.rates, x => x.country == "Australia");
        }

        [Fact]
        public async Task GetExchangeRatesToday_Fail_ServerDown()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://test.com")
            };

            ICNBHttpClient cnbHttpClient = new CNBHttpClient(httpClient, _options);

            await Assert.ThrowsAsync<HttpRequestException>(cnbHttpClient.GetExchangeRatesToday);
        }
    }
}
