namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class TimeSeries
    {
        public TimeSeries(decimal open, decimal high, decimal low, decimal close)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }       
    }
}