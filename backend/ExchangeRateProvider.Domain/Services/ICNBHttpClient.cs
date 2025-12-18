using ExchangeRateProvider.Domain.Common;

namespace ExchangeRateProvider.Domain.Services
{
    public interface ICNBHttpClient
    {
        Task<Rates> GetExchangeRatesToday();
    }
}
