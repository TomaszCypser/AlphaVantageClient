using System;
using AlphaVantageClient.Forex.Models;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;
using RealTimeExchangeRate = AlphaVantageClient.Forex.Serialization.RealTimeExchangeRate;

namespace AlphaVantageClient.Forex.Mappers
{
    public class RealTimeExchangeRateResponseMapperProfile : Profile
    {
        public RealTimeExchangeRateResponseMapperProfile()
        {
            CreateMap<RealTimeExchangeRateApiResponse?, Forex.Models.RealTimeExchangeRateResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.RealTimeExchangeRate is null) throw new ArgumentNullException(nameof(source.RealTimeExchangeRate));

                    return new RealTimeExchangeRateResponse
                    (
                        context.Mapper.Map<RealTimeExchangeRate, Forex.Models.RealTimeExchangeRate>(source.RealTimeExchangeRate)
                    );
                });
            
            CreateMap<RealTimeExchangeRate?, Forex.Models.RealTimeExchangeRate>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.FromCurrencyCode)) throw new ArgumentException($"Provided value for {nameof(source.FromCurrencyCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.FromCurrencyName)) throw new ArgumentException($"Provided value for {nameof(source.FromCurrencyName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ToCurrencyCode)) throw new ArgumentException($"Provided value for {nameof(source.ToCurrencyCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ToCurrencyName)) throw new ArgumentException($"Provided value for {nameof(source.ToCurrencyName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ExchangeRate)) throw new ArgumentException($"Provided value for {nameof(source.ExchangeRate)} cannot be null or empty.");
                    if(!decimal.TryParse(source.ExchangeRate, out decimal exchangeRateConverted)) throw new ArgumentException($"Provided value for {nameof(source.ExchangeRate)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Timezone)) throw new ArgumentException($"Provided value for {nameof(source.Timezone)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ExchangeRate)) throw new ArgumentException($"Provided value for {nameof(source.ExchangeRate)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.AskPrice)) throw new ArgumentException($"Provided value for {nameof(source.AskPrice)} cannot be null or empty.");
                    if(!decimal.TryParse(source.AskPrice, out decimal askPriceConverted)) throw new ArgumentException($"Provided value for {nameof(source.AskPrice)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.BidPrice)) throw new ArgumentException($"Provided value for {nameof(source.BidPrice)} cannot be null or empty.");
                    if(!decimal.TryParse(source.BidPrice, out decimal bidPriceConverted)) throw new ArgumentException($"Provided value for {nameof(source.BidPrice)} is not a valid number.");

                    return new Forex.Models.RealTimeExchangeRate
                    (
                        source.FromCurrencyCode,
                        source.FromCurrencyName,
                        source.ToCurrencyCode,
                        source.ToCurrencyName,
                        exchangeRateConverted,
                        source.LastRefreshed,
                        source.Timezone,
                        bidPriceConverted,
                        askPriceConverted
                    );
                });
        }
    }
}