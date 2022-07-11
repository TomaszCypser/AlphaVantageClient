using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class IntradayTimeSeries
    {
        [JsonPropertyName("open")]
        public string? Open { get; set; }

        [JsonPropertyName("high")]
        public string? High { get; set; }

        [JsonPropertyName("low")]
        public string? Low { get; set; }

        [JsonPropertyName("close")]
        public string? Close { get; set; }       

        [JsonPropertyName("volume")]
        public long? Volume { get; set; }
    }
}