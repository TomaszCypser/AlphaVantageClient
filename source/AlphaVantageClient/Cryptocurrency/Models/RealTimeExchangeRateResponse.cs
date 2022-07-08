namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class RealTimeExchangeRateResponse
    {
        public RealTimeExchangeRateResponse(RealTimeExchangeRate realTimeExchangeRate)
        {
            RealTimeExchangeRate = realTimeExchangeRate;
        }

        public RealTimeExchangeRate RealTimeExchangeRate { get; }
    }
    public class RealTimeExchangeRate
    {
        public RealTimeExchangeRate(string fromCurrencyCode, string fromCurrencyName, string toCurrencyCode, string toCurrencyName, decimal exchangeRate, string lastRefreshed, string timezone, decimal bidPrice, decimal askPrice)
        {
            FromCurrencyCode = fromCurrencyCode;
            FromCurrencyName = fromCurrencyName;
            ToCurrencyCode = toCurrencyCode;
            ToCurrencyName = toCurrencyName;
            ExchangeRate = exchangeRate;
            LastRefreshed = lastRefreshed;
            Timezone = timezone;
            BidPrice = bidPrice;
            AskPrice = askPrice;
        }

        public string FromCurrencyCode { get; }
        public string FromCurrencyName { get; }
        public string ToCurrencyCode { get; }
        public string ToCurrencyName { get; }
        public decimal ExchangeRate { get; }
        public string LastRefreshed { get; }
        public string Timezone { get; }
        public decimal BidPrice { get; }
        public decimal AskPrice { get; }
    }
}