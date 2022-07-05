using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlphaVantageClient.Stock.Serialization
{
    internal class StockTimeSeriesApiResponse
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

        [JsonPropertyName("Symbol")]
        public string? Symbol { get; set; }

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

        [JsonPropertyName("adjusted close")]
        public string? AdjustedClose { get; set; }

        [JsonPropertyName("dividend amount")]
        public string? DividendAmount { get; set; }

        [JsonPropertyName("volume")]
        public string? Volume { get; set; }

        [JsonPropertyName("split coefficient")]
        public string? SplitCoefficient { get; set; }
    }
}