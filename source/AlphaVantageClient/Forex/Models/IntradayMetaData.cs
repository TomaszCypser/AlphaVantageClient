namespace AlphaVantageClient.Forex.Models
{
    public class IntradayMetaData : MetaData
    {
        public IntradayMetaData(string information, string fromSymbol, string toSymbol, string lastRefreshed, string interval, string outputSize, string timeZone)
            : base(information, fromSymbol, toSymbol, lastRefreshed, timeZone)
        {
            Interval = interval;
            OutputSize = outputSize;
        }

        public string Interval { get; }
        public string OutputSize { get; }
    }
}