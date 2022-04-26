using System.Collections.Generic;

namespace AlphaVantageClient.Models
{
    public class MonthlyAdjustedResponse
    {
        public MonthlyAdjustedResponse(MonthlyAdjustedMetaData metaData, Dictionary<string, MonthlyAdjustedTimeSeries> timeseries)
        {
            MetaData = metaData;
            TimeSeries = timeseries;
        }

        public MonthlyAdjustedMetaData MetaData { get; }
        public Dictionary<string, MonthlyAdjustedTimeSeries> TimeSeries { get; }
    }

    public class MonthlyAdjustedMetaData
    {
        public MonthlyAdjustedMetaData(string information, string symbol, string lastRefreshed, string timeZone)
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


    public class MonthlyAdjustedTimeSeries
    {
        public MonthlyAdjustedTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal adjustedClose, decimal dividendAmount, long volume)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            AdjustedClose = adjustedClose;
            DividendAmount = dividendAmount;
            Volume = volume;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public decimal AdjustedClose { get; }
        public decimal DividendAmount { get; }
        public long Volume { get; }
    }
}