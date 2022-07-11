namespace AlphaVantageClient.Stock.Models
{
    public class QuoteResponse
    {
        public QuoteResponse(GlobalQuote globalQuote)
        {
            GlobalQuote = globalQuote;
        }

        public GlobalQuote GlobalQuote { get;  }
    }
}