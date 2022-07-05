using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class WeeklyAdjustedResponse
    {
        public WeeklyAdjustedResponse(WeeklyAdjustedMetaData metaData, Dictionary<string, WeeklyAdjustedTimeSeries> timeseries)
        {
            MetaData = metaData;
            TimeSeries = timeseries;
        }

        public WeeklyAdjustedMetaData MetaData { get; }
        public Dictionary<string, WeeklyAdjustedTimeSeries> TimeSeries { get; }
    }

    public class WeeklyAdjustedMetaData
    {
        public WeeklyAdjustedMetaData(string information, string symbol, string lastRefreshed, string timeZone)
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


    public class WeeklyAdjustedTimeSeries
    {
        public WeeklyAdjustedTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal adjustedClose, decimal dividendAmount, long volume)
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