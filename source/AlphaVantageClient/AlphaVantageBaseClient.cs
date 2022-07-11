using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;

namespace AlphaVantageClient
{
    public abstract class AlphaVantageBaseClient
    {
        protected HttpClient HttpClient { get; }
        protected IMapper Mapper { get; }
        protected string GetBaseRequestUrl() => $"{HttpClient.BaseAddress}/query";

        protected AlphaVantageBaseClient(HttpClient httpClient, IMapper mapper)
        {
            HttpClient = httpClient;
            Mapper = mapper;
        }
        
        protected async Task<T> GetApiResponse<TU,T>(Dictionary<string,string> queryParameters, CancellationToken cancellationToken) 
            where T : class
            where TU : class
        {
            var baseAddress = GetBaseRequestUrl();
            var requestUrl = QueryHelpers.AddQueryString(baseAddress, queryParameters);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage, cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = JsonSerializer.Deserialize<TU?>(await httpResponseMessage.Content.ReadAsStringAsync());
            return Mapper.Map<TU?, T>(response);
        }
    }
}