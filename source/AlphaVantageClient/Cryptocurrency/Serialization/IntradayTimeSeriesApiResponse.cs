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
}