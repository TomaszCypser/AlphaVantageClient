using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class DailyResponse
    {
        public DailyResponse(DailyMetaData metaData, Dictionary<string, TimeSeries> dailyTimeS)
        {
            MetaData = metaData;
            TimeSeries = dailyTimeS;
        }

        public DailyMetaData MetaData { get; }
        public Dictionary<string, TimeSeries> TimeSeries { get; }
    }
}