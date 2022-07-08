using System;
using System.Collections.Generic;
using AlphaVantageClient.Cryptocurrency.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Cryptocurrency.Mappers
{
    public class DailyResponseMapperProfile : Profile
    {
        public DailyResponseMapperProfile()
        {
            CreateMap<TimeSeriesApiResponse?, Models.DailyResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.DailyResponse
                    (
                        context.Mapper.Map<Serialization.MetaData, Models.DailyMetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.DailyTimeSeries>>(source.TimeSeries)
                    );
                });

            CreateMap<Serialization.MetaData, Models.DailyMetaData>()
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
                    
                    return new Models.DailyMetaData
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

            CreateMap<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.DailyTimeSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse =  new Dictionary<string, Models.DailyTimeSeries>();
                    foreach(var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<Serialization.TimeSeries, Models.DailyTimeSeries>(item.Value)
                            );
                    }
                    return mappedResponse;
                });

            CreateMap<Serialization.TimeSeries, Models.DailyTimeSeries>()
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

                    return new Models.DailyTimeSeries
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