using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class WeeklyResponse
    {
        public WeeklyResponse(WeeklyMetaData metaData, Dictionary<string, WeeklyTimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public WeeklyMetaData MetaData { get; }
        public Dictionary<string, WeeklyTimeSeries> TimeSeries { get; }
    }

    public class WeeklyMetaData
    {
        public WeeklyMetaData(string information, string symbol, string lastRefreshed, string timeZone)
        {
            Information = information;
            Symbol = symbol;
            LastRefreshed = lastRefreshed;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string Symbol { get; }
        public string LastRefreshed { get; }
        public string TimeZone { get; }
    }


    public class WeeklyTimeSeries
    {
        public WeeklyTimeSeries(decimal open, decimal high, decimal low, decimal close, long volume)
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