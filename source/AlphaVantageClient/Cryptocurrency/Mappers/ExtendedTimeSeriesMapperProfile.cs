using System;
using System.Collections.Generic;
using AlphaVantageClient.Cryptocurrency.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Cryptocurrency.Mappers
{
    public class ExtendedTimeSeriesMapperProfile : Profile
    {
        public ExtendedTimeSeriesMapperProfile()
        {
            CreateMap<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.ExtendedTimesSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse =  new Dictionary<string, Models.ExtendedTimesSeries>();
                    foreach(var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<Serialization.TimeSeries, Models.ExtendedTimesSeries>(item.Value)
                            );
                    }
                    return mappedResponse;
                });

            CreateMap<Serialization.TimeSeries, Models.ExtendedTimesSeries>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.Close)) throw new ArgumentException($"Provided value for {nameof(source.Close)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Close, out decimal closeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Close)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if(!decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.CloseUSD)) throw new ArgumentException($"Provided value for {nameof(source.CloseUSD)} cannot be null or empty.");
                    if(!decimal.TryParse(source.CloseUSD, out decimal closeUsdConverted)) throw new ArgumentException($"Provided value for {nameof(source.CloseUSD)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.HighUSD)) throw new ArgumentException($"Provided value for {nameof(source.HighUSD)} cannot be null or empty.");
                    if(!decimal.TryParse(source.HighUSD, out decimal highUsdConverted)) throw new ArgumentException($"Provided value for {nameof(source.HighUSD)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.LowUSD)) throw new ArgumentException($"Provided value for {nameof(source.LowUSD)} cannot be null or empty.");
                    if(!decimal.TryParse(source.LowUSD, out decimal lowUsdConverted)) throw new ArgumentException($"Provided value for {nameof(source.LowUSD)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.OpenUSD)) throw new ArgumentException($"Provided value for {nameof(source.OpenUSD)} cannot be null or empty.");
                    if(!decimal.TryParse(source.OpenUSD, out decimal openUsdConverted)) throw new ArgumentException($"Provided value for {nameof(source.OpenUSD)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.MarketCap)) throw new ArgumentException($"Provided value for {nameof(source.MarketCap)} cannot be null or empty.");
                    if(!decimal.TryParse(source.MarketCap, out decimal marketCapConverted)) throw new ArgumentException($"Provided value for {nameof(source.MarketCap)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Volume)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Volume, out decimal volumeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} is not a valid number.");

                    return new Models.ExtendedTimesSeries
                    (
                        openConverted,
                        highConverted,
                        lowConverted,
                        closeConverted,
                        openUsdConverted,
                        highUsdConverted,
                        lowUsdConverted,
                        closeUsdConverted,
                        marketCapConverted,
                        volumeConverted
                    );
                });
        }
    }
}