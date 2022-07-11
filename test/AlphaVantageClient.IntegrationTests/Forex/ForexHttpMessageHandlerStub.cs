using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AlphaVantageClient.Forex
{
    public class ForexHttpMessageHandlerStub : HttpMessageHandler
    {
        private readonly HttpClient _httpClient;

        public ForexHttpMessageHandlerStub()
        {
            _httpClient = new HttpClient();
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            switch (request.RequestUri!.AbsoluteUri)
            {
                case { } url when url.Contains("CURRENCY_EXCHANGE_RATE"): 
                    return await StubGetCurrencyExchangeRate(request, cancellationToken); 
                case { } url when url.Contains("FX_INTRADAY"): 
                    return await StubGetIntradayTimeSeries(request, cancellationToken);
                case { } url when url.Contains("FX_DAILY"): 
                    return await StubGetDailyTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("FX_WEEKLY"): 
                    return await StubGetWeeklyTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("FX_MONTHLY"): 
                    return await StubGetMonthlyTimeSeries(request, cancellationToken);
                default:
                    throw new ArgumentException("Provided unexpected RequestUri, currently stub does not support this scenario.");
            }
        }

        private async Task<HttpResponseMessage> StubGetMonthlyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_symbol=EUR"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=EUR&to_symbol=USD&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'FX_MONTHLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetWeeklyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_symbol=EUR"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_WEEKLY&from_symbol=EUR&to_symbol=USD&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'FX_WEEKLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetDailyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full", "from_symbol=EUR"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_DAILY&from_symbol=EUR&to_symbol=USD&outputsize=full&apikey=demo",cancellationToken)) }); 
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_symbol=EUR"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_DAILY&from_symbol=EUR&to_symbol=USD&apikey=demo",cancellationToken)) }); 
            throw new ArgumentException("Unexpected parameters for 'FX_DAILY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetCurrencyExchangeRate(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_currency=BTC"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=CNY&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_currency=USD"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=USD&to_currency=JPY&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'CURRENCY_EXCHANGE_RATE' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetIntradayTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_INTRADAY&from_symbol=EUR&to_symbol=USD&interval=5min&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("from_symbol=EUR"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=FX_INTRADAY&from_symbol=EUR&to_symbol=USD&interval=5min&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'FX_INTRADAY' Request, currently stub does not support this scenario.");
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
