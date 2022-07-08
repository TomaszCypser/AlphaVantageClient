using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class TimeSeriesApiResponse
    {
        [JsonPropertyName("Meta Data")]
        public MetaData? MetaData { get; set; }

        [JsonPropertyName("Time Series")]
        public Dictionary<string, TimeSeries>? TimeSeries { get; set; }
    }
    
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