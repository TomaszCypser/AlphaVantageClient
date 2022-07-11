using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Cryptocurrency.Models;
using AlphaVantageClient.Models;
using AlphaVantageClient.Utils;
using AutoMapper;

namespace AlphaVantageClient.Cryptocurrency
{
    public class CryptocurrencyClient : AlphaVantageBaseClient, ICryptocurrencyClient
    {
        public CryptocurrencyClient(HttpClient httpClient, IMapper mapper) : base(httpClient, mapper) { }
        
        public async Task<IntradayResponse> GetIntradayTimeSeries(string symbol, string market, Interval interval, OutputSize outputSize,
            CancellationToken cancellationToken = default)
            => await GetApiResponse<Serialization.IntradayTimeSeriesApiResponse,IntradayResponse>(GetIntradayTimeSeriesQueryParameters(symbol, market, interval, outputSize), cancellationToken);

        public async Task<DailyResponse> GetDailyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default)
            => await GetTimeSeries<DailyResponse>(GetDailyTimeSeriesQueryParameters(symbol, market), cancellationToken);

        public async Task<WeeklyResponse> GetWeeklyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default)
            => await GetTimeSeries<WeeklyResponse>(GetWeeklyTimeSeriesQueryParameters(symbol, market), cancellationToken);

        public async Task<MonthlyResponse> GetMonthlyTimeSeries(string symbol, string market, CancellationToken cancellationToken = default)
            => await GetTimeSeries<MonthlyResponse>(GetMonthlyTimeSeriesQueryParameters(symbol, market), cancellationToken);

        private async Task<T> GetTimeSeries<T>(Dictionary<string,string> queryParameters, CancellationToken cancellationToken)
            where T : class
            => await GetApiResponse<Serialization.TimeSeriesApiResponse,T>(queryParameters, cancellationToken);
        
        private static Dictionary<string, string> GetWeeklyTimeSeriesQueryParameters(string symbol, string market)
            => new Dictionary<string,string>
            {
                {"function","DIGITAL_CURRENCY_WEEKLY"},
                {"symbol", symbol},
                {"market", market}
            };
        
        private static Dictionary<string, string> GetMonthlyTimeSeriesQueryParameters(string symbol, string market)
            => new Dictionary<string,string>
            {
                {"function","DIGITAL_CURRENCY_MONTHLY"},
                {"symbol", symbol},
                {"market", market}
            };
        
        private static Dictionary<string, string> GetDailyTimeSeriesQueryParameters(string symbol, string market)
            => new Dictionary<string,string>
            {
                {"function","DIGITAL_CURRENCY_DAILY"},
                {"symbol", symbol},
                {"market", market}
            };
        
        private static Dictionary<string, string> GetIntradayTimeSeriesQueryParameters(string symbol, string market, Interval interval, OutputSize outputSize)
            => new Dictionary<string,string>
            {
                {"function","CRYPTO_INTRADAY"},
                {"symbol", symbol},
                {"market", market},
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