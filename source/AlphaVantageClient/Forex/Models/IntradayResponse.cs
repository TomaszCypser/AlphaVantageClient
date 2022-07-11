using System.Collections.Generic;

namespace AlphaVantageClient.Forex.Models
{
    public class IntradayResponse
    {
        public IntradayResponse(IntradayMetaData metaData, Dictionary<string, TimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public IntradayMetaData MetaData { get; }
        public Dictionary<string, TimeSeries> TimeSeries { get; }
    }
}