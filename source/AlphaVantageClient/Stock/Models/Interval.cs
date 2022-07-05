using AlphaVantageClient.Utils;

namespace AlphaVantageClient.Stock.Models
{
    public enum Interval
    {
        [QueryValue("1min")]
        OneMinute,
        [QueryValue("5min")]
        FiveMinutes,
        [QueryValue("15min")]
        FifteenMinutes,
        [QueryValue("30min")]
        ThirtyMinutes,
        [QueryValue("60min")]
        SixtyMinutes
    }
}