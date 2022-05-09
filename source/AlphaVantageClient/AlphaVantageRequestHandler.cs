using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AlphaVantageClient.Utils;

namespace AlphaVantageClient
{
    internal class AlphaVantageRequestHandler : DelegatingHandler
    {
        private readonly string _apiKey;
        public AlphaVantageRequestHandler(string apiKey)  : this(new HttpClientHandler(), apiKey) { }
        public AlphaVantageRequestHandler(HttpMessageHandler innerHandler, string apiKey) : base(innerHandler)
        {
            _apiKey = apiKey;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            if (string.IsNullOrEmpty(uriBuilder.Query)) uriBuilder.Query = $"apikey={_apiKey}";
            else uriBuilder.Query = $"{uriBuilder.Query}&apikey={_apiKey}";
            request.RequestUri = uriBuilder.Uri;
            return await base.SendAsync(request, cancellationToken).ContinueWith(
                (task) =>
                {
                    HttpResponseMessage response = task.Result;
                    var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    response.Content = new StringContent(ResponseCleaner.GetCleanAlphaVantageResponse(responseContent));
                    return response;
                }
            );
        }
    }
}