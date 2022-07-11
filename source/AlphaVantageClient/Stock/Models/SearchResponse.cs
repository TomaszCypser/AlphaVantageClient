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
}