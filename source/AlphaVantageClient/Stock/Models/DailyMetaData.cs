namespace AlphaVantageClient.Stock.Models
{
    public class DailyMetaData : MetaData
    {
        public DailyMetaData(string information, string symbol, string lastRefreshed, string outputSize, string timeZone)
            : base(information, symbol, lastRefreshed, timeZone)
        {
            OutputSize = outputSize;
        }

        public string OutputSize { get; }
    }
}