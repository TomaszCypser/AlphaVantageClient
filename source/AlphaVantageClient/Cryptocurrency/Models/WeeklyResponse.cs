using System.Collections.Generic;

namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class WeeklyResponse
    {
        public WeeklyResponse(MetaData metaData, Dictionary<string, ExtendedTimesSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, ExtendedTimesSeries> TimeSeries { get; }
    }
}