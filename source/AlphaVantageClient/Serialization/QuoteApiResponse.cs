using System;
using System.Text.Json.Serialization;

namespace AlphaVantageClient.Serialization
{
    internal class QuoteApiResponse
    {
        [JsonPropertyName("Global Quote")]
        public GlobalQuote? GlobalQuote { get; set; }
    }

    internal class GlobalQuote
    {
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("open")]
        public string? Open { get; set; }

        [JsonPropertyName("high")]
        public string? High { get; set; }

        [JsonPropertyName("low")]
        public string? Low { get; set; }

        [JsonPropertyName("price")]
        public string? Price { get; set; }

        [JsonPropertyName("volume")]
        public string? Volume { get; set; }

        [JsonPropertyName("latest trading day")]
        public string? LatestTradingDay { get; set; }

        [JsonPropertyName("previous close")]
        public string? PreviousClose { get; set; }

        [JsonPropertyName("change")]
        public string? Change { get; set; }

        [JsonPropertyName("change percent")]
        public string? ChangePercent { get; set; }
    }
}