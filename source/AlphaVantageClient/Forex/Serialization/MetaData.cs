using System.Text.Json.Serialization;

namespace AlphaVantageClient.Forex.Serialization
{
    internal class MetaData
    {
        [JsonPropertyName("Information")]
        public string? Information { get; set; }

        [JsonPropertyName("From Symbol")]
        public string? FromSymbol { get; set; }

        [JsonPropertyName("To Symbol")]
        public string? ToSymbol { get; set; }

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