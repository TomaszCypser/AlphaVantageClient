using System;
using System.Collections.Generic;
using AlphaVantageClient.Cryptocurrency.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Cryptocurrency.Mappers
{
    public class MetaDataMapperProfile : Profile
    {
        public MetaDataMapperProfile()
        {
            CreateMap<Serialization.MetaData, Models.MetaData>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Information)) throw new ArgumentException($"Provided value for {nameof(source.Information)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketCode)) throw new ArgumentException($"Provided value for {nameof(source.MarketCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketName)) throw new ArgumentException($"Provided value for {nameof(source.MarketName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.DigitalCurrencyCode)) throw new ArgumentException($"Provided value for {nameof(source.DigitalCurrencyCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.DigitalCurrencyName)) throw new ArgumentException($"Provided value for {nameof(source.DigitalCurrencyName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");
                    
                    return new Models.MetaData
                    (
                        source.Information,
                        source.DigitalCurrencyCode,
                        source.DigitalCurrencyName,
                        source.MarketCode,
                        source.MarketName,
                        source.LastRefreshed,
                        source.TimeZone
                    );
                });
        }
    }
}