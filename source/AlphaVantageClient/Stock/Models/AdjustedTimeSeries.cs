namespace AlphaVantageClient.Stock.Models
{
    public class AdjustedTimeSeries : TimeSeries
    {
        public AdjustedTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal adjustedClose, decimal dividendAmount, long volume)
            : base(open, high, low, close, volume)
        {
            AdjustedClose = adjustedClose;
            DividendAmount = dividendAmount;
        }

        public decimal AdjustedClose { get; }
        public decimal DividendAmount { get; }
    }
}