using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
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

    public class IntradayMetaData
    {
        public IntradayMetaData(string information, string symbol, string lastRefreshed, string interval, string outputSize, string timeZone)
        {
            Information = information;
            Symbol = symbol;
            LastRefreshed = lastRefreshed;
            Interval = interval;
            OutputSize = outputSize;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string Symbol { get; }
        public string LastRefreshed { get; }
        public string Interval { get; }
        public string OutputSize { get; }
        public string TimeZone { get; }
    }

    public class IntradayTimeSeries
    {
        public IntradayTimeSeries(decimal open, decimal high, decimal low, decimal close, long volume)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public long Volume { get; }
    }
}