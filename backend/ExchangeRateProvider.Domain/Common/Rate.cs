namespace ExchangeRateProvider.Domain.Common
{
    public record Rate(string date, int order, string country, string curreny, int amount, string currenyCode, decimal rate);
}
