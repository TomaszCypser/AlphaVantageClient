using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlphaVantageClient.Cryptocurrency.Serialization
{
    internal class IntradayTimeSeriesApiResponse
    {
        [JsonPropertyName("Meta Data")]
        public MetaData? MetaData { get; set; }

        [JsonPropertyName("Time Series")]
        public Dictionary<string, IntradayTimeSeries>? TimeSeries { get; set; }
    }

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