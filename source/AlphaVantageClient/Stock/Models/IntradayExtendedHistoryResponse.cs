using System.Collections.Generic;

namespace AlphaVantageClient.Stock.Models
{
    public class IntradayExtendedHistoryResponse
    {
        public IntradayExtendedHistoryResponse(ICollection<IntradayExtendedHistoryTimeSeries> intradayExtendedHistoryTimeSeries)
        {
            IntradayExtendedHistoryTimeSeries = intradayExtendedHistoryTimeSeries;
        }

        public ICollection<IntradayExtendedHistoryTimeSeries> IntradayExtendedHistoryTimeSeries { get; }
    }

    public class IntradayExtendedHistoryTimeSeries
    {
        public IntradayExtendedHistoryTimeSeries(string time, decimal high, decimal open, decimal close, decimal low, long volume)
        {
            Time = time;
            High = high;
            Open = open;
            Close = close;
            Low = low;
            Volume = volume;
        }

        public string Time { get; }
        public decimal High { get; }
        public decimal Open { get; }
        public decimal Close { get; }
        public decimal Low { get; }
        public long Volume { get; }
    }
}