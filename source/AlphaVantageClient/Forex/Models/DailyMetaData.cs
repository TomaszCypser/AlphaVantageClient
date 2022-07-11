namespace AlphaVantageClient.Forex.Models
{
    public class DailyMetaData : MetaData
    {
        public DailyMetaData(string information, string fromSymbol, string toSymbol, string outputSize, string lastRefreshed, string timeZone)
            : base(information, fromSymbol, toSymbol, lastRefreshed, timeZone)
        {
            OutputSize = outputSize;
        }

        public string OutputSize { get; }
    }
}