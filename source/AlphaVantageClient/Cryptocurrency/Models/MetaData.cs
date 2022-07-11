namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class MetaData
    {
        public MetaData(string information, string digitalCurrencyCode, string digitalCurrencyName, string marketCode, string marketName, string lastRefreshed, string timeZone)
        {
            Information = information;
            DigitalCurrencyCode = digitalCurrencyCode;
            DigitalCurrencyName = digitalCurrencyName;
            MarketCode = marketCode;
            MarketName = marketName;
            LastRefreshed = lastRefreshed;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string DigitalCurrencyCode { get; }
        public string DigitalCurrencyName { get; }
        public string MarketCode { get; }
        public string MarketName { get; }
        public string LastRefreshed { get; }
        public string TimeZone { get; }
    }
}