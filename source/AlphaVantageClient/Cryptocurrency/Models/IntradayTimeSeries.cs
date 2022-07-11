namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class IntradayTimeSeries : TimeSeries
    {
        public IntradayTimeSeries(decimal open, decimal high, decimal low, decimal close, long volume) : base(open, high, low, close)
        {
            Volume = volume;
        }
        
        public long Volume { get; }
    }
}