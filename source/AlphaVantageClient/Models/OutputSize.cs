using AlphaVantageClient.Utils;

namespace AlphaVantageClient.Models
{
    public enum OutputSize
    {
        [QueryValue("compact")]
        Compact,
        [QueryValue("full")]
        Full
    }
}