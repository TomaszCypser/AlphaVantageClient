namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class ExtendedTimesSeries : TimeSeries
    {
        public ExtendedTimesSeries(decimal open, decimal high, decimal low, decimal close, decimal openUsd, decimal highUsd, decimal lowUsd, decimal closeUsd, decimal marketCapUsd, decimal volume)
            : base(open, high, low, close)
        {
            OpenUSD = openUsd;
            HighUSD = highUsd;
            LowUSD = lowUsd;
            CloseUSD = closeUsd;
            MarketCapUSD = marketCapUsd;
            Volume = volume;
        }

        public decimal OpenUSD { get; }
        public decimal HighUSD { get; }
        public decimal LowUSD { get; }
        public decimal CloseUSD { get; }
        public decimal MarketCapUSD { get; }
        public decimal Volume { get; }
    }
}