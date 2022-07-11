namespace AlphaVantageClient.Stock.Models
{
    public class IntradayMetaData : MetaData
    {
        public IntradayMetaData(string information, string symbol, string lastRefreshed, string interval, string outputSize, string timeZone)
            : base(information, symbol, lastRefreshed, timeZone)
        {
            Interval = interval;
            OutputSize = outputSize;
        }

        public string Interval { get; }
        public string OutputSize { get; }
    }
}