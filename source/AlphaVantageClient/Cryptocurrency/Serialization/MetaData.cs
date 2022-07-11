using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class MetaData
    {
        [JsonPropertyName("Information")]
        public string? Information { get; set; }

        [JsonPropertyName("Digital Currency Code")]
        public string? DigitalCurrencyCode { get; set; }

        [JsonPropertyName("Digital Currency Name")]
        public string? DigitalCurrencyName { get; set; }

        [JsonPropertyName("Market Code")]
        public string? MarketCode { get; set; }

        [JsonPropertyName("Market Name")]
        public string? MarketName { get; set; }

        [JsonPropertyName("Last Refreshed")]
        public string? LastRefreshed { get; set; }

        [JsonPropertyName("Interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("Output Size")]
        public string? OutputSize { get; set; }
        
        [JsonPropertyName("Time Zone")]
        public string? TimeZone { get; set; }
    }
}