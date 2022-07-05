using CsvHelper.Configuration.Attributes;

namespace AlphaVantageClient.Stock.Serialization
{
    internal class IntradayExtendedHistoryApiResponse
    {
        [Name("time")]
        public string? Time { get; set; }
        [Name("high")]
        public string? High { get; set; }
        [Name("open")]
        public string? Open { get; set; }
        [Name("close")]
        public string? Close { get; set; }
        [Name("low")]
        public string? Low { get; set; }
        [Name("volume")]
        public string? Volume { get; set; }
    }
}