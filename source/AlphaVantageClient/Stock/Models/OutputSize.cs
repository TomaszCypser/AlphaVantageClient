using AlphaVantageClient.Utils;

namespace AlphaVantageClient.Stock.Models
{
    public enum OutputSize
    {
        [QueryValue("compact")]
        Compact,
        [QueryValue("full")]
        Full
    }
}