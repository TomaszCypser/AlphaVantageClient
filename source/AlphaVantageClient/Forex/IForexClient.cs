using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Forex.Models;
using AlphaVantageClient.Models;

namespace AlphaVantageClient.Forex
{
    public interface IForexClient
    {
        Task<RealTimeExchangeRateResponse> GetCurrencyExchangeRate(string fromCurrency, string toCurrency, CancellationToken cancellationToken = default);
        Task<IntradayResponse> GetIntradayTimeSeries(string fromSymbol, string toSymbol, Interval interval, OutputSize outputSize, CancellationToken cancellationToken = default);
        Task<DailyResponse> GetDailyTimeSeries(string fromSymbol, string toSymbol, OutputSize outputSize, CancellationToken cancellationToken = default);
        Task<WeeklyResponse> GetWeeklyTimeSeries(string fromSymbol, string toSymbol, CancellationToken cancellationToken = default);
        Task<MonthlyResponse> GetMonthlyTimeSeries(string fromSymbol, string toSymbol, CancellationToken cancellationToken = default);
    }
}