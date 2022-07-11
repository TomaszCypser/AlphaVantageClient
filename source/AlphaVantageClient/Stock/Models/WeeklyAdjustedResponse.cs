using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class WeeklyAdjustedResponse
    {
        public WeeklyAdjustedResponse(MetaData metaData, Dictionary<string, AdjustedTimeSeries> timeseries)
        {
            MetaData = metaData;
            TimeSeries = timeseries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, AdjustedTimeSeries> TimeSeries { get; }
    }
}