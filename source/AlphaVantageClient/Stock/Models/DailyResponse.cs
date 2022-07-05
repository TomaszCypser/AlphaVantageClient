using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class DailyResponse
    {
        public DailyResponse(DailyMetaData metaData, Dictionary<string, DailyTimeSeries> dailyTimeS)
        {
            MetaData = metaData;
            TimeSeries = dailyTimeS;
        }

        public DailyMetaData MetaData { get; }
        public Dictionary<string, DailyTimeSeries> TimeSeries { get; }
    }

    public class DailyMetaData
    {
        public DailyMetaData(string information, string symbol, string lastRefreshed, string outputSize, string timeZone)
        {
            Information = information;
            Symbol = symbol;
            LastRefreshed = lastRefreshed;
            OutputSize = outputSize;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string Symbol { get; }
        public string LastRefreshed { get; }
        public string OutputSize { get; }
        public string TimeZone { get; }
    }

    public class DailyTimeSeries
    {
        public DailyTimeSeries(decimal open, decimal high, decimal low, decimal close, long volume)
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