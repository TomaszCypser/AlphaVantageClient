using System;
using System.Collections.Generic;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Forex.Mappers
{
    public class IntradayResponseMapperProfile : Profile
    {
        public IntradayResponseMapperProfile()
        {
            CreateMap<TimeSeriesApiResponse?, Models.IntradayResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.IntradayResponse
                    (
                        context.Mapper.Map<MetaData, Models.IntradayMetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, TimeSeries>, Dictionary<string, Models.TimeSeries>>(source.TimeSeries)
                    );
                });

            CreateMap<MetaData, Models.IntradayMetaData>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Information)) throw new ArgumentException($"Provided value for {nameof(source.Information)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.OutputSize)) throw new ArgumentException($"Provided value for {nameof(source.OutputSize)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Interval)) throw new ArgumentException($"Provided value for {nameof(source.Interval)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.FromSymbol)) throw new ArgumentException($"Provided value for {nameof(source.FromSymbol)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ToSymbol)) throw new ArgumentException($"Provided value for {nameof(source.ToSymbol)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");
                    
                    return new Models.IntradayMetaData
                    (
                        source.Information,
                        source.FromSymbol,
                        source.ToSymbol,
                        source.LastRefreshed,
                        source.Interval,
                        source.OutputSize,
                        source.TimeZone
                    );
                });
        }
    }
}