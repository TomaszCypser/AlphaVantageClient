using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AlphaVantageClient.Cryptocurrency
{
    public class CryptocurrencyHttpMessageHandlerStub : HttpMessageHandler
    {
        private readonly HttpClient _httpClient;

        public CryptocurrencyHttpMessageHandlerStub()
        {
            _httpClient = new HttpClient();
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            switch (request.RequestUri!.AbsoluteUri)
            {
                case { } url when url.Contains("CRYPTO_INTRADAY"): 
                    return await StubGetIntradayTimeSeries(request, cancellationToken);
                case { } url when url.Contains("DIGITAL_CURRENCY_DAILY"): 
                    return await StubGetDailyTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("DIGITAL_CURRENCY_WEEKLY"): 
                    return await StubGetWeeklyTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("DIGITAL_CURRENCY_MONTHLY"): 
                    return await StubGetMonthlyTimeSeries(request, cancellationToken);
                default:
                    throw new ArgumentException("Provided unexpected RequestUri, currently stub does not support this scenario.");
            }
        }

        private async Task<HttpResponseMessage> StubGetMonthlyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=BTC"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_MONTHLY&symbol=BTC&market=CNY&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'DIGITAL_CURRENCY_MONTHLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetWeeklyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=BTC"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_WEEKLY&symbol=BTC&market=CNY&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'DIGITAL_CURRENCY_WEEKLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetDailyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=BTC"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_DAILY&symbol=BTC&market=CNY&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'DIGITAL_CURRENCY_DAILY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetIntradayTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=CRYPTO_INTRADAY&symbol=ETH&market=USD&interval=5min&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=ETH"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=CRYPTO_INTRADAY&symbol=ETH&market=USD&interval=5min&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'CRYPTO_INTRADAY' Request, currently stub does not support this scenario.");
        }

        private async Task<string> GetUrlResponse(string requestUrl, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();
            return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
