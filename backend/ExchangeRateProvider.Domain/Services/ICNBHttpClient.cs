namespace ExchangeRateProvider.Domain.Services
{
    public interface ICNBHttpClient
    {
        Task GetExchangeRatesToday();
    }
}
