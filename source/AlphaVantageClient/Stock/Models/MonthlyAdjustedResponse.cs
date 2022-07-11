using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class MonthlyAdjustedResponse
    {
        public MonthlyAdjustedResponse(MetaData metaData, Dictionary<string, AdjustedTimeSeries> timeseries)
        {
            MetaData = metaData;
            TimeSeries = timeseries;
        }

        public MetaData MetaData { get; }
        public Dictionary<string, AdjustedTimeSeries> TimeSeries { get; }
    }
}