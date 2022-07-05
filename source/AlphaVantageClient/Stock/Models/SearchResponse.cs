namespace AlphaVantageClient.Stock.Models
{
    public class SearchResponse
    {
        public SearchResponse(BestMatches[]? bestMatches)
        {
            BestMatches = bestMatches;
        }

        public BestMatches[]? BestMatches { get; }
    }

    public class BestMatches
    {
        public BestMatches(string symbol, string name, string type, string region, string marketOpen, string marketClose, string timeZone, string currency, decimal matchScore)
        {
            Symbol = symbol;
            Name = name;
            Type = type;
            Region = region;
            MarketOpen = marketOpen;
            MarketClose = marketClose;
            TimeZone = timeZone;
            Currency = currency;
            MatchScore = matchScore;
        }

        public string Symbol { get; }
        public string Name { get; }
        public string Type { get; }
        public string Region { get; }
        public string MarketOpen { get; }
        public string MarketClose { get; }
        public string TimeZone { get; }
        public string Currency { get; }
        public decimal MatchScore { get; }
    }
}