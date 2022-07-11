namespace AlphaVantageClient.Stock.Models
{
    public class TimeSeries
    {
        public TimeSeries(decimal open, decimal high, decimal low, decimal close, long volume)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public long Volume { get; }
    }
}