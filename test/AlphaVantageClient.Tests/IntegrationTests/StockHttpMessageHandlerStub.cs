using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AlphaVantageClient.IntegrationTests
{
    public class StockHttpMessageHandlerStub : HttpMessageHandler
    {
        private readonly HttpClient _httpClient;

        public StockHttpMessageHandlerStub()
        {
            _httpClient = new HttpClient();
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            switch (request.RequestUri!.AbsoluteUri)
            {
                case { } url when url.Contains("TIME_SERIES_INTRADAY_EXTENDED"): 
                    return await StubGetIntradayExtendedTimeSeries(request, cancellationToken); 
                case { } url when url.Contains("TIME_SERIES_INTRADAY"): 
                    return await StubGetIntradayTimeSeries(request, cancellationToken);
                case { } url when url.Contains("TIME_SERIES_DAILY_ADJUSTED"): 
                    return await StubGetDailyAdjustedTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("TIME_SERIES_DAILY"): 
                    return await StubGetDailyTimeSeries(request, cancellationToken);   
                case { } url when url.Contains("TIME_SERIES_MONTHLY_ADJUSTED"): 
                    return await StubGetMonthlyAdjustedTimeSeries(request, cancellationToken);
                case { } url when url.Contains("TIME_SERIES_MONTHLY"): 
                    return await StubGetMonthlyTimeSeries(request, cancellationToken);     
                case { } url when url.Contains("TIME_SERIES_WEEKLY_ADJUSTED"): 
                    return await StubGetWeeklyAdjustedTime(request, cancellationToken);
                case { } url when url.Contains("TIME_SERIES_WEEKLY"): 
                    return await StubGetWeeklyTimeSeries(request, cancellationToken);
                case { } url when url.Contains("GLOBAL_QUOTE"): 
                    return await StubGetQuote(request, cancellationToken);         
                case { } url when url.Contains("SYMBOL_SEARCH"): 
                    return await StubGetSearch(request, cancellationToken);
                default:
                    throw new ArgumentException("Provided unexpected RequestUri, currently stub does not support this scenario.");
            }
        }

        private async Task<HttpResponseMessage> StubGetQuote(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=300135.SHZ"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=300135.SHZ&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'GLOBAL_QUOTE' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetSearch(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("keywords=tesco"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=tesco&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("keywords=tencent"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=tencent&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("keywords=BA"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=BA&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("keywords=SAIC"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=SAIC&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'SYMBOL_SEARCH' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetMonthlyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol=TSCO.LON&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol=IBM&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_MONTHLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetWeeklyAdjustedTime(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY_ADJUSTED&symbol=TSCO.LON&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY_ADJUSTED&symbol=IBM&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_WEEKLY_ADJUSTED' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetWeeklyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY&symbol=TSCO.LON&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_WEEKLY&symbol=IBM&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_WEEKLY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetMonthlyAdjustedTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY_ADJUSTED&symbol=TSCO.LON&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY_ADJUSTED&symbol=IBM&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_MONTHLY_ADJUSTED' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetDailyTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full", "symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=IBM&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=TSCO.LON&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=SHOP.TRT"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=SHOP.TRT&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=GPV.TRV"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=GPV.TRV&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=DAI.DEX"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=DAI.DEX&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=RELIANCE.BSE"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=RELIANCE.BSE&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=600104.SHH"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=600104.SHH&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=000002.SHZ"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=000002.SHZ&outputsize=full&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_DAILY' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetDailyAdjustedTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full", "symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=IBM&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=IBM&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=TSCO.LON"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=TSCO.LON&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=SHOP.TRT"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=SHOP.TRT&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=GPV.TRV"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=GPV.TRV&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=DAI.DEX"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=DAI.DEX&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=RELIANCE.BSE"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=RELIANCE.BSE&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=600104.SHH"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=600104.SHH&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("symbol=000002.SHZ"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=000002.SHZ&outputsize=full&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_DAILY_ADJUSTED' Request, currently stub does not support this scenario.");
        }

        private async Task<HttpResponseMessage> StubGetIntradayExtendedTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("slice=year1month1", "symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY_EXTENDED&symbol=IBM&interval=15min&slice=year1month1&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("slice=year1month2", "symbol=IBM"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY_EXTENDED&symbol=IBM&interval=15min&slice=year1month2&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("slice=year1month3", "symbol=IBM", "adjusted=false"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY_EXTENDED&symbol=IBM&interval=60min&slice=year1month3&adjusted=false&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_INTRADAY' Request, currently stub does not support this scenario.");

        }

        private async Task<HttpResponseMessage> StubGetIntradayTimeSeries(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsoluteUri.ContainsAll("outputsize=full"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&outputsize=full&apikey=demo",cancellationToken)) });
            if (request.RequestUri!.AbsoluteUri.ContainsAll("interval=5min"))
                return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(await GetUrlResponse("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo",cancellationToken)) });
            throw new ArgumentException("Unexpected parameters for 'TIME_SERIES_INTRADAY' Request, currently stub does not support this scenario.");
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
