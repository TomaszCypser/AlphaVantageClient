namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class IntradayMetaData : MetaData
    {
        public IntradayMetaData(string information, string digitalCurrencyCode, string digitalCurrencyName, string marketCode, string marketName, string lastRefreshed, string interval, string outputSize, string timeZone)
            : base(information, digitalCurrencyCode, digitalCurrencyName, marketCode, marketName, lastRefreshed, timeZone)
        {
            Interval = interval;
            OutputSize = outputSize;
        }

        public string Interval { get; }
        public string OutputSize { get; }
    }
}