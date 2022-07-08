using System;
using System.Collections.Generic;
using AlphaVantageClient.Cryptocurrency.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Cryptocurrency.Mappers
{
    public class IntradayResponseMapperProfile : Profile
    {
        public IntradayResponseMapperProfile()
        {
            CreateMap<IntradayTimeSeriesApiResponse?, Models.IntradayResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.IntradayResponse
                    (
                        context.Mapper.Map<Serialization.MetaData, Models.IntradayMetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.IntradayTimeSeries>, Dictionary<string, Models.IntradayTimeSeries>>(source.TimeSeries)
                    );
                });

            CreateMap<Serialization.MetaData, Models.IntradayMetaData>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Information)) throw new ArgumentException($"Provided value for {nameof(source.Information)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.OutputSize)) throw new ArgumentException($"Provided value for {nameof(source.OutputSize)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Interval)) throw new ArgumentException($"Provided value for {nameof(source.Interval)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketCode)) throw new ArgumentException($"Provided value for {nameof(source.MarketCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketName)) throw new ArgumentException($"Provided value for {nameof(source.MarketName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.DigitalCurrencyCode)) throw new ArgumentException($"Provided value for {nameof(source.DigitalCurrencyCode)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.DigitalCurrencyName)) throw new ArgumentException($"Provided value for {nameof(source.DigitalCurrencyName)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");
                    
                    return new Models.IntradayMetaData
                    (
                        source.Information,
                        source.DigitalCurrencyCode,
                        source.DigitalCurrencyName,
                        source.MarketCode,
                        source.MarketName,
                        source.LastRefreshed,
                        source.Interval,
                        source.OutputSize,
                        source.TimeZone
                    );
                });

            CreateMap<Dictionary<string, Serialization.IntradayTimeSeries>, Dictionary<string, Models.IntradayTimeSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse =  new Dictionary<string, Models.IntradayTimeSeries>();
                    foreach(var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<Serialization.IntradayTimeSeries, Models.IntradayTimeSeries>(item.Value)
                            );
                    }
                    return mappedResponse;
                });

            CreateMap<Serialization.IntradayTimeSeries, Models.IntradayTimeSeries>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.Volume is null) throw new ArgumentNullException(nameof(source.Volume));
                    if(string.IsNullOrEmpty(source.Close)) throw new ArgumentException($"Provided value for {nameof(source.Close)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Close, out decimal closeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Close)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if(!decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if(!decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");

                    return new Models.IntradayTimeSeries
                    (
                        openConverted,
                        highConverted,
                        lowConverted,
                        closeConverted,
                        source.Volume.Value
                    );
                });
        }
    }
}