namespace AlphaVantageClient.Stock.Models
{
    public class MetaData
    {
        public MetaData(string information, string symbol, string lastRefreshed, string timeZone)
        {
            Information = information;
            Symbol = symbol;
            LastRefreshed = lastRefreshed;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string Symbol { get; }
        public string LastRefreshed { get; }
        public string TimeZone { get; }
    }
}