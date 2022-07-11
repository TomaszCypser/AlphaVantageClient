using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class DailyAdjustedResponse
    {
        public DailyAdjustedResponse(DailyMetaData metaData, Dictionary<string, DailyAdjustedTimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public DailyMetaData MetaData { get; }
        public Dictionary<string, DailyAdjustedTimeSeries> TimeSeries { get; }
    }
}