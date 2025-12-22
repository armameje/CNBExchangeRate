using ExchangeRateProvider.Domain.Common;
using ExchangeRateProvider.Domain.DTO;

namespace ExchangeRateProvider.Domain.Services
{
    public interface ICNBHttpClient
    {
        Task<Rates> GetExchangeRatesTodayAsync();
    }
}
