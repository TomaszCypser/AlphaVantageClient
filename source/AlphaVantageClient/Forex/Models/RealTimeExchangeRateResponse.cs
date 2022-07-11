namespace AlphaVantageClient.Forex.Models
{
    public class RealTimeExchangeRateResponse
    {
        public RealTimeExchangeRateResponse(RealTimeExchangeRate realTimeExchangeRate)
        {
            RealTimeExchangeRate = realTimeExchangeRate;
        }

        public RealTimeExchangeRate RealTimeExchangeRate { get; }
    }
}