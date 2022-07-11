using System.Text.Json.Serialization;

namespace AlphaVantageClient.Stock.Serialization
{
    internal class SearchApiResponse
    {
        [JsonPropertyName("bestMatches")]
        public BestMatches[]? BestMatches { get; set; }
    }

    internal class BestMatches
    {
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("marketOpen")]
        public string? MarketOpen { get; set; }

        [JsonPropertyName("marketClose")]
        public string? MarketClose { get; set; }

        [JsonPropertyName("timezone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("matchScore")]
        public string? MatchScore { get; set; }
    }
}