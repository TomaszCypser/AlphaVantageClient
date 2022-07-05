using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class MonthlyResponse
    {
        public MonthlyResponse(MonthlyMetaData metaData, Dictionary<string, MonthlyTimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public MonthlyMetaData MetaData { get; }
        public Dictionary<string, MonthlyTimeSeries> TimeSeries { get; }
    }

    public class MonthlyMetaData
    {
        public MonthlyMetaData(string information, string symbol, string lastRefreshed, string timeZone)
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


    public class MonthlyTimeSeries
    {
        public MonthlyTimeSeries(decimal open, decimal high, decimal low, decimal close, long volume)
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