using System.Collections.Generic;

namespace AlphaVantageClient.Cryptocurrency.Models
{
    public class IntradayResponse
    {
        public IntradayResponse(IntradayMetaData metaData, Dictionary<string, IntradayTimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public IntradayMetaData MetaData { get; }
        public Dictionary<string, IntradayTimeSeries> TimeSeries { get; }
    }
}