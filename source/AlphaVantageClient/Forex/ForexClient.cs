using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Forex.Models;
using AlphaVantageClient.Models;
using AlphaVantageClient.Utils;
using AutoMapper;

namespace AlphaVantageClient.Forex
{
    public class ForexClient : AlphaVantageBaseClient, IForexClient
    {
        public ForexClient(HttpClient httpClient, IMapper mapper) : base(httpClient, mapper) { }
        
        public async Task<RealTimeExchangeRateResponse> GetCurrencyExchangeRate(string fromCurrency, string toCurrency, CancellationToken cancellationToken = default)
            => await GetApiResponse<Serialization.RealTimeExchangeRateApiResponse,RealTimeExchangeRateResponse>(GetCurrencyExchangeRateQueryParameters(fromCurrency,toCurrency), cancellationToken);
   
        public async Task<IntradayResponse> GetIntradayTimeSeries(string fromSymbol, string toSymbol, Interval interval, OutputSize outputSize,
            CancellationToken cancellationToken = default)
            => await GetTimeSeries<IntradayResponse>(GetIntradayTimeSeriesQueryParameters(fromSymbol, toSymbol, interval, outputSize), cancellationToken);
        
        public async Task<DailyResponse> GetDailyTimeSeries(string fromSymbol, string toSymbol, OutputSize outputSize, CancellationToken cancellationToken = default)
            => await GetTimeSeries<DailyResponse>(GetDailyTimeSeriesQueryParameters(fromSymbol, toSymbol, outputSize), cancellationToken);

        public async Task<WeeklyResponse> GetWeeklyTimeSeries(string fromSymbol, string toSymbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<WeeklyResponse>(GetWeeklyTimeSeriesQueryParameters(fromSymbol, toSymbol), cancellationToken);

        public async Task<MonthlyResponse> GetMonthlyTimeSeries(string fromSymbol, string toSymbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<MonthlyResponse>(GetMonthlyTimeSeriesQueryParameters(fromSymbol, toSymbol), cancellationToken);

        private async Task<T> GetTimeSeries<T>(Dictionary<string,string> queryParameters, CancellationToken cancellationToken)
            where T : class
            => await GetApiResponse<Serialization.TimeSeriesApiResponse,T>(queryParameters, cancellationToken);
        
        private static Dictionary<string, string> GetWeeklyTimeSeriesQueryParameters(string symbol, string toSymbol)
            => new Dictionary<string,string>
            {
                {"function","FX_WEEKLY"},
                {"from_symbol", symbol},
                {"to_symbol", toSymbol}
            };
        
        private static Dictionary<string, string> GetMonthlyTimeSeriesQueryParameters(string fromSymbol, string toSymbol)
            => new Dictionary<string,string>
            {
                {"function","FX_MONTHLY"},
                {"from_symbol", fromSymbol},
                {"to_symbol", toSymbol}
            };
        
        private static Dictionary<string, string> GetDailyTimeSeriesQueryParameters(string fromSymbol, string toSymbol, OutputSize outputSize)
            => new Dictionary<string,string>
            {
                {"function","FX_DAILY"},
                {"from_symbol", fromSymbol},
                {"to_symbol", toSymbol},
                {"outputsize", outputSize.GetAttribute<QueryValueAttribute>()}
            };
        
        private static Dictionary<string, string> GetIntradayTimeSeriesQueryParameters(string fromSymbol, string toSymbol, Interval interval, OutputSize outputSize)
            => new Dictionary<string,string>
            {
                {"function","FX_INTRADAY"},
                {"from_symbol", fromSymbol},
                {"to_symbol", toSymbol},
                {"interval", interval.GetAttribute<QueryValueAttribute>()},
                {"outputsize", outputSize.GetAttribute<QueryValueAttribute>()}
            };
        
        private static Dictionary<string,string> GetCurrencyExchangeRateQueryParameters(string fromCurrency, string toCurrency)
            => new Dictionary<string,string>
            {
                {"function","CURRENCY_EXCHANGE_RATE"},
                {"from_currency", fromCurrency},
                {"to_currency", toCurrency}
            };
    }
}