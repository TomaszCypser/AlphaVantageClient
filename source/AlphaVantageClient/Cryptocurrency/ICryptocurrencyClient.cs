using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Cryptocurrency.Models;
using AlphaVantageClient.Models;

namespace AlphaVantageClient.Cryptocurrency
{
    public interface ICryptocurrencyClient
    {
        Task<IntradayResponse> GetIntradayTimeSeries(string symbol, string market, Interval interval, OutputSize outputSize, CancellationToken cancellationToken = default);
        Task<DailyResponse> GetDailyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default);
        Task<WeeklyResponse> GetWeeklyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default);
        Task<MonthlyResponse> GetMonthlyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default);
    }
}