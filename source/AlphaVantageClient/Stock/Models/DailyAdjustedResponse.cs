using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class DailyAdjustedResponse
    {
        public DailyAdjustedResponse(DailyAdjustedMetaData metaData, Dictionary<string, DailyAdjustedTimeSeries> timeSeries)
        {
            MetaData = metaData;
            TimeSeries = timeSeries;
        }

        public DailyAdjustedMetaData MetaData { get; }
        public Dictionary<string, DailyAdjustedTimeSeries> TimeSeries { get; }
    }

    public class DailyAdjustedMetaData
    {
        public DailyAdjustedMetaData(string information, string symbol, string lastRefreshed, string outputSize, string timeZone)
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


    public class DailyAdjustedTimeSeries
    {
        public DailyAdjustedTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal adjustedClose, decimal dividendAmount, long volume, decimal splitCoefficient)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            AdjustedClose = adjustedClose;
            DividendAmount = dividendAmount;
            Volume = volume;
            SplitCoefficient = splitCoefficient;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public decimal AdjustedClose { get; }
        public decimal DividendAmount { get; }
        public long Volume { get; }
        public decimal SplitCoefficient { get; }
    }
}