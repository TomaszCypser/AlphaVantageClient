namespace AlphaVantageClient.Stock.Models
{
    public class DailyAdjustedTimeSeries : AdjustedTimeSeries
    {
        public DailyAdjustedTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal adjustedClose, decimal dividendAmount, long volume, decimal splitCoefficient)
            : base(open, high, low, close, adjustedClose, dividendAmount, volume)
        {
            SplitCoefficient = splitCoefficient;
        }

        public decimal SplitCoefficient { get; }
    }
}