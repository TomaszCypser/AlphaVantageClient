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
}