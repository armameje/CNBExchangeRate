namespace ExchangeRateProvider.Domain.Common
{
    public record Rate(string validFor, int order, string country, string currency, int amount, string currencyCode, decimal rate);
}
