using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlphaVantageClient.Utils
{
    internal static class ResponseCleaner
    {
        private static IReadOnlyDictionary<string, string> PatternReplacementValueDictionary 
            => new Dictionary<string,string> 
                {
                    {"\"(.*\\. Meta Data)\"", "Meta Data"},
                    {"\"(.*\\. Information)\"", "Information"},
                    {"\"(.*\\. Symbol)\"", "Symbol"},
                    {"\"(.*\\. Last Refreshed)\"", "Last Refreshed"},
                    {"\"(.*\\. Time Zone)\"", "Time Zone"},
                    {"\"(.*\\. Output Size)\"", "Output Size"}, 
                    {"\"(.*\\. Interval)\"", "Interval"},
                    {"\"(Time Series.*)\"", "Time Series"},
                    {"\"(Monthly Time Series.*)\"", "Time Series"},
                    {"\"(Monthly Adjusted Time Series.*)\"", "Time Series"},
                    {"\"(Weekly Time Series.*)\"", "Time Series"},
                    {"\"(Weekly Adjusted Time Series.*)\"", "Time Series"},
                    {"\"(.*\\. symbol)\"", "symbol"},
                    {"\"(.*\\. name)\"", "name"},
                    {"\"(.*\\. type)\"", "type"},
                    {"\"(.*\\. region)\"", "region"},
                    {"\"(.*\\. marketOpen)\"", "marketOpen"},
                    {"\"(.*\\. marketClose)\"", "marketClose"},
                    {"\"(.*\\. timezone)\"", "timezone"},
                    {"\"(.*\\. currency)\"", "currency"},
                    {"\"(.*\\. matchScore)\"", "matchScore"},
                    {"\"(.*\\. open)\"", "open"},
                    {"\"(.*\\. high)\"", "high"},
                    {"\"(.*\\. low)\"", "low"},
                    {"\"(.*\\. price)\"", "price"},
                    {"\"(.*\\. latest trading day)\"", "latest trading day"},
                    {"\"(.*\\. previous close)\"", "previous close"},
                    {"\"(.*\\. change)\"", "change"},
                    {"\"(.*\\. change percent)\"", "change percent"},
                    {"\"(.*\\. close)\"", "close"},
                    {"\"(.*\\. adjusted close)\"", "adjusted close"},
                    {"\"(.*\\. volume)\"", "volume"},
                    {"\"(.*\\. dividend amount)\"", "dividend amount"},
                    {"\"(.*\\. split coefficient)\"", "split coefficient"},            
                    {"\"(.*\\. Digital Currency Code)\"", "Digital Currency Code"},
                    {"\"(.*\\. Digital Currency Name)\"", "Digital Currency Name"},
                    {"\"(.*\\. Market Code)\"", "Market Code"},
                    {"\"(.*\\. Market Name)\"", "Market Name"},
                    {"\"(.*\\. From_Currency Code)\"", "From_Currency Code"},
                    {"\"(.*\\. From_Currency Name)\"", "From_Currency Name"},
                    {"\"(.*\\. To_Currency Code)\"", "To_Currency Code"},
                    {"\"(.*\\. To_Currency Name)\"", "To_Currency Name"},
                    {"\"(.*\\. Exchange Rate)\"", "Exchange Rate"},
                    {"\"(.*\\. Bid Price)\"", "Bid Price"},
                    {"\"(.*\\. Ask Price)\"", "Ask Price"},
                    {"\"(1a.*\\. open \\(.*\\))\"", "open"},
                    {"\"(1b.*\\. open \\(USD\\))\"", "open (USD)"},
                    {"\"(2a.*\\. high \\(.*\\))\"", "high"},
                    {"\"(2b.*\\. high \\(USD\\))\"", "high (USD)"},
                    {"\"(3a.*\\. low \\(.*\\))\"", "low"},
                    {"\"(3b.*\\. low \\(USD\\))\"", "low (USD)"},
                    {"\"(4a.*\\. close \\(.*\\))\"", "close"},
                    {"\"(4b.*\\. close \\(USD\\))\"", "close (USD)"},
                    {"\"(.*\\. market cap \\(USD\\))\"", "market cap (USD)"},
                };

        public static string GetCleanAlphaVantageResponse(string serviceResponse)
        {
            foreach(var patternToReplace in PatternReplacementValueDictionary)
            {
                serviceResponse = Regex.Replace(serviceResponse, patternToReplace.Key, $"\"{patternToReplace.Value}\"");
            }
            return serviceResponse;
        }
    }
}