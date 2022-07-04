using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Models;
using AlphaVantageClient.Utils;
using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.WebUtilities;

namespace AlphaVantageClient
{
    public class StockClient : IStockClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private string GetBaseRequestUrl() => $"{_httpClient.BaseAddress}/query";

        public StockClient(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<DailyAdjustedResponse> GetDailyAdjustedTimeSeries(string symbol, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default)
            => await GetTimeSeries<DailyAdjustedResponse>(GetDailyAdjustedTimeSeriesQueryParameters(symbol, outputSize), cancellationToken);
        public async Task<DailyResponse> GetDailyTimeSeries(string symbol, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default)
            => await GetTimeSeries<DailyResponse>(GetDailyTimeSeriesQueryParameters(symbol, outputSize), cancellationToken);
        public async Task<IntradayResponse> GetIntradayTimeSeries(string symbol, Interval interval, bool adjusted = true, OutputSize outputSize = OutputSize.Compact, CancellationToken cancellationToken = default)
            => await GetTimeSeries<IntradayResponse>(GetIntradayTimeSeriesQueryParameters(symbol, interval, adjusted, outputSize), cancellationToken);
        public async Task<MonthlyResponse> GetMonthlyTimeSeries(string symbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<MonthlyResponse>(GetMonthlyTimeSeriesQueryParameters(symbol), cancellationToken);
        public async Task<MonthlyAdjustedResponse> GetMonthlyAdjustedTimeSeries(string symbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<MonthlyAdjustedResponse>(GetMonthlyAdjustedTimeSeriesQueryParameters(symbol), cancellationToken);
        public async Task<WeeklyResponse> GetWeeklyTimeSeries(string symbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<WeeklyResponse>(GetWeeklyTimeSeriesQueryParameters(symbol), cancellationToken);
        public async Task<WeeklyAdjustedResponse> GetWeeklyAdjustedTimeSeries(string symbol, CancellationToken cancellationToken = default)
            => await GetTimeSeries<WeeklyAdjustedResponse>(GetWeeklyAdjustedTimeSeriesQueryParameters(symbol), cancellationToken);
        public async Task<QuoteResponse> GetQuote(string symbol, CancellationToken cancellationToken = default)
            => await GetApiResponse<Serialization.QuoteApiResponse, QuoteResponse>(GetQuoteQueryParameters(symbol), cancellationToken);
        public async Task<SearchResponse> SearchSymbol(string keywords, CancellationToken cancellationToken = default)
            => await GetApiResponse<Serialization.SearchApiResponse, SearchResponse>(GetSearchQueryParameters(keywords), cancellationToken);
        
        public async Task<IntradayExtendedHistoryResponse> GetIntradayTimeSeriesExtendedHistory(string symbol, Interval interval, bool adjusted = true, Slice slice = Slice.Year1month1, CancellationToken cancellationToken = default)
        {
            var baseAddress = GetBaseRequestUrl();
            var requestUrl = QueryHelpers.AddQueryString(baseAddress, GetIntradayExtendedTimeSeriesQueryParameters(symbol, interval, adjusted, slice));
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(requestUrl)))
            {
                using (var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture))
                    {
                        var response = csvReader.GetRecords<Serialization.IntradayExtendedHistoryApiResponse>();
                        return _mapper.Map<IEnumerable<Serialization.IntradayExtendedHistoryApiResponse>?, IntradayExtendedHistoryResponse>(response);
                    }
                }
            }
        }

        private static Dictionary<string,string> GetIntradayExtendedTimeSeriesQueryParameters(string symbol, Interval interval, bool adjusted = true, Slice slice = Slice.Year1month1)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_INTRADAY_EXTENDED"},
                    {"symbol", symbol},
                    {"interval", interval.GetAttribute<QueryValueAttribute>()},
                    {"adjusted", adjusted.ToString()},
                    {"slice", slice.GetAttribute<QueryValueAttribute>()},
                    {"datatype", "json"}
                };

        private static Dictionary<string,string> GetDailyAdjustedTimeSeriesQueryParameters(string symbol, OutputSize outputSize)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_DAILY_ADJUSTED"},
                    {"symbol", symbol},
                    {"outputsize", outputSize.GetAttribute<QueryValueAttribute>()},
                    {"datatype", "json"}
                };

        private static Dictionary<string,string> GetDailyTimeSeriesQueryParameters(string symbol, OutputSize outputSize)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_DAILY"},
                    {"symbol", symbol},
                    {"outputsize", outputSize.GetAttribute<QueryValueAttribute>()},
                    {"datatype", "json"}
                };

        private static Dictionary<string,string> GetIntradayTimeSeriesQueryParameters(string symbol, Interval interval, bool adjusted, OutputSize outputSize)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_INTRADAY"},
                    {"symbol", symbol},
                    {"interval", interval.GetAttribute<QueryValueAttribute>()},
                    {"adjusted", adjusted.ToString()},
                    {"outputsize", outputSize.GetAttribute<QueryValueAttribute>()},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetMonthlyAdjustedTimeSeriesQueryParameters(string symbol)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_MONTHLY_ADJUSTED"},
                    {"symbol", symbol},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetWeeklyTimeSeriesQueryParameters(string symbol)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_WEEKLY"},
                    {"symbol", symbol},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetWeeklyAdjustedTimeSeriesQueryParameters(string symbol)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_WEEKLY_ADJUSTED"},
                    {"symbol", symbol},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetMonthlyTimeSeriesQueryParameters(string symbol)
            => new Dictionary<string,string>()
                {
                    {"function","TIME_SERIES_MONTHLY"},
                    {"symbol", symbol},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetQuoteQueryParameters(string symbol)
            => new Dictionary<string,string>()
                {
                    {"function","GLOBAL_QUOTE"},
                    {"symbol", symbol},
                    {"datatype", "json"}
                };

        private static Dictionary<string, string> GetSearchQueryParameters(string keywords)
            => new Dictionary<string,string>()
                {
                    {"function","SYMBOL_SEARCH"},
                    {"keywords", keywords},
                    {"datatype", "json"}
                };

        private async Task<T> GetTimeSeries<T>(Dictionary<string,string> queryParameters, CancellationToken cancellationToken)
            where T : class
            => await GetApiResponse<Serialization.StockTimeSeriesApiResponse,T>(queryParameters, cancellationToken);

        private async Task<T> GetApiResponse<U,T>(Dictionary<string,string> queryParameters, CancellationToken cancellationToken) 
            where T : class
            where U : class
        {
            var baseAddress = GetBaseRequestUrl();
            var requestUrl = QueryHelpers.AddQueryString(baseAddress, queryParameters);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = JsonSerializer.Deserialize<U?>(await httpResponseMessage.Content.ReadAsStringAsync());
            return _mapper.Map<U?, T>(response);
        }
    }
}
