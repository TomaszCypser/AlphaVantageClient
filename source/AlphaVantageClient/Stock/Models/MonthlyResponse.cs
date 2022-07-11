using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class MonthlyResponse
    {
        public MonthlyResponse(MetaData metaData, Dictionary<string, TimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, TimeSeries> TimeSeries { get; }
    }
}