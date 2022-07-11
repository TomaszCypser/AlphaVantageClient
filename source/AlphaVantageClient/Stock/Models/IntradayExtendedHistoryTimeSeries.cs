namespace AlphaVantageClient.Stock.Models
{
    public class IntradayExtendedHistoryTimeSeries : TimeSeries
    {
        public IntradayExtendedHistoryTimeSeries(string time, decimal high, decimal open, decimal close, decimal low, long volume)
            : base(open, high, low, close, volume)
        {
            Time = time;
        }

        public string Time { get; }
    }
}