using System.Collections.Generic;

namespace AlphaVantageClient.Cryptocurrency.Models
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
        public WeeklyMetaData(string information, string digitalCurrencyCode, string digitalCurrencyName, string marketCode, string marketName, string lastRefreshed, string timeZone)
        {
            Information = information;
            DigitalCurrencyCode = digitalCurrencyCode;
            DigitalCurrencyName = digitalCurrencyName;
            MarketCode = marketCode;
            MarketName = marketName;
            LastRefreshed = lastRefreshed;
            TimeZone = timeZone;
        }

        public string Information { get; }
        public string DigitalCurrencyCode { get; }
        public string DigitalCurrencyName { get; }
        public string MarketCode { get; }
        public string MarketName { get; }
        public string LastRefreshed { get; }
        public string TimeZone { get; }
    }


    public class WeeklyTimeSeries
    {
        public WeeklyTimeSeries(decimal open, decimal high, decimal low, decimal close, decimal openUsd, decimal highUsd, decimal lowUsd, decimal closeUsd, decimal marketCapUsd, decimal volume)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            OpenUSD = openUsd;
            HighUSD = highUsd;
            LowUSD = lowUsd;
            CloseUSD = closeUsd;
            MarketCapUSD = marketCapUsd;
            Volume = volume;
        }

        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }       
        public decimal OpenUSD { get; }
        public decimal HighUSD { get; }
        public decimal LowUSD { get; }
        public decimal CloseUSD { get; }
        public decimal MarketCapUSD { get; }
        public decimal Volume { get; }
    }
}