using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Stock.Models;

namespace AlphaVantageClient.Stock
{
    public interface IStockClient
    {
        Task<Models.IntradayResponse> GetIntradayTimeSeries(string symbol, Interval interval, bool adjusted = true, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default);
        Task<Models.IntradayExtendedHistoryResponse> GetIntradayTimeSeriesExtendedHistory(string symbol, Interval interval, bool adjusted = true, Slice slice = Slice.Year1month1, CancellationToken cancellationToken = default);
        Task<Models.DailyResponse> GetDailyTimeSeries(string symbol, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default);
        Task<Models.DailyAdjustedResponse> GetDailyAdjustedTimeSeries(string symbol, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default);
        Task<Models.WeeklyResponse> GetWeeklyTimeSeries(string symbol, CancellationToken cancellationToken = default);
        Task<Models.WeeklyAdjustedResponse> GetWeeklyAdjustedTimeSeries(string symbol, CancellationToken cancellationToken = default);
        Task<Models.MonthlyResponse> GetMonthlyTimeSeries(string symbol, CancellationToken cancellationToken = default);
        Task<Models.MonthlyAdjustedResponse> GetMonthlyAdjustedTimeSeries(string symbol, CancellationToken cancellationToken = default);
        Task<QuoteResponse> GetQuote(string symbol, CancellationToken cancellationToken = default);
        Task<SearchResponse> SearchSymbol(string keywords, CancellationToken cancellationToken = default);
    }
}
