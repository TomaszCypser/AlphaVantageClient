using System.Text.Json.Serialization;

namespace AlphaVantageClient.Forex.Serialization
{
    internal class RealTimeExchangeRateApiResponse
    {
        [JsonPropertyName("Realtime Currency Exchange Rate")]
        public RealTimeExchangeRate? RealTimeExchangeRate { get; set; }
    }
}