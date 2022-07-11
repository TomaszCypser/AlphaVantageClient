using System.Collections.Generic;

namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class DailyResponse
    {
        public DailyResponse(MetaData metaData, Dictionary<string, ExtendedTimesSeries> dailyTimeSeries)
        {
            MetaData = metaData;
            TimeSeries = dailyTimeSeries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, ExtendedTimesSeries> TimeSeries { get; }
    }
}