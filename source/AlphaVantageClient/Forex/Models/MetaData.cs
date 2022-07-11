namespace AlphaVantageClient.Forex.Models
{
    public class MetaData
    {
        public MetaData(string information, string fromSymbol, string toSymbol, string lastRefreshed, string timeZone)
        {
            Information = information;
            FromSymbol = fromSymbol;
            ToSymbol = toSymbol;
            LastRefreshed = lastRefreshed;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string FromSymbol { get; }
        public string ToSymbol { get; }
        public string LastRefreshed { get; }
        public string TimeZone { get; }
    }
}