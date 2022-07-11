using System.Collections.Generic;

namespace AlphaVantageClient.Forex.Models
{
    public class WeeklyResponse
    {
        public WeeklyResponse(MetaData metaData, Dictionary<string, TimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, TimeSeries> TimeSeries { get; }
    }
}