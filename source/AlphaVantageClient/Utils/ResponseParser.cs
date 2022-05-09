using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlphaVantageClient.Utils
{
    internal static class ResponseCleaner
    {
        private static IReadOnlyDictionary<string, string> PatternReplacementValueDictionary 
            => new Dictionary<string,string> 
                {
                    {"\"(.*Meta Data)\"", "Meta Data"},
                    {"\"(.*Information)\"", "Information"},
                    {"\"(.*Symbol)\"", "Symbol"},
                    {"\"(.*Last Refreshed)\"", "Last Refreshed"},
                    {"\"(.*Time Zone)\"", "Time Zone"},
                    {"\"(.*Output Size)\"", "Output Size"}, 
                    {"\"(.*Interval)\"", "Interval"},
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