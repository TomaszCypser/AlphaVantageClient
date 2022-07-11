using System.Collections.Generic;

namespace AlphaVantageClient.Forex.Models
{
    public class DailyResponse
    {
        public DailyResponse(DailyMetaData metaData, Dictionary<string, TimeSeries> dailyTimeSeries)
        {
            MetaData = metaData;
            TimeSeries = dailyTimeSeries;
        }

        public DailyMetaData MetaData { get; }
        public Dictionary<string, TimeSeries> TimeSeries { get; }
    }
}