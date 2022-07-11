using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class TimeSeries
    {
        [JsonPropertyName("open")]
        public string? Open { get; set; }

        [JsonPropertyName("high")]
        public string? High { get; set; }

        [JsonPropertyName("low")]
        public string? Low { get; set; }

        [JsonPropertyName("close")]
        public string? Close { get; set; }       
        
        [JsonPropertyName("open (USD)")]
        public string? OpenUSD { get; set; }

        [JsonPropertyName("high (USD)")]
        public string? HighUSD { get; set; }

        [JsonPropertyName("low (USD)")]
        public string? LowUSD { get; set; }

        [JsonPropertyName("close (USD)")]
        public string? CloseUSD { get; set; }

        [JsonPropertyName("market cap (USD)")]
        public string? MarketCap { get; set; }

        [JsonPropertyName("volume")]
        public string? Volume { get; set; }
    }
}