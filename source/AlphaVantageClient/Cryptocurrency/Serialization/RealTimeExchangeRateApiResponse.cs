using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class RealTimeExchangeRateApiResponse
    {
        [JsonPropertyName("Realtime Currency Exchange Rate")]
        public RealTimeExchangeRate? RealTimeExchangeRate { get; set; }
    }
    
    internal class RealTimeExchangeRate
    {
        [JsonPropertyName("From_Currency Code")]
        public string? FromCurrencyCode { get; set; }

        [JsonPropertyName("From_Currency Name")]
        public string? FromCurrencyName { get; set; }

        [JsonPropertyName("To_Currency Code")]
        public string? ToCurrencyCode { get; set; }

        [JsonPropertyName("To_Currency Name")]
        public string? ToCurrencyName { get; set; }

        [JsonPropertyName("Exchange Rate")]
        public string? ExchangeRate { get; set; }

        [JsonPropertyName("Last Refreshed")]
        public string? LastRefreshed { get; set; }

        [JsonPropertyName("Time Zone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("Bid Price")]
        public string? BidPrice { get; set; }
        
        [JsonPropertyName("Ask Price")]
        public string? AskPrice { get; set; }
    }
}