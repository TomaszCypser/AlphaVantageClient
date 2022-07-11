using System;
using System.Collections.Generic;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Forex.Mappers
{
    public class MetaDataMapperProfile : Profile
    {
        public MetaDataMapperProfile()
        {
            CreateMap<MetaData, Models.MetaData>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if (source is null) throw new ArgumentNullException(nameof(source));
                    if (string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if (string.IsNullOrEmpty(source.Information)) throw new ArgumentException($"Provided value for {nameof(source.Information)} cannot be null or empty.");
                    if (string.IsNullOrEmpty(source.FromSymbol)) throw new ArgumentException($"Provided value for {nameof(source.FromSymbol)} cannot be null or empty.");
                    if (string.IsNullOrEmpty(source.ToSymbol)) throw new ArgumentException($"Provided value for {nameof(source.ToSymbol)} cannot be null or empty.");
                    if (string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");

                    return new Models.MetaData
                    (
                        source.Information,
                        source.FromSymbol,
                        source.ToSymbol,
                        source.LastRefreshed,
                        source.TimeZone
                    );
                });
        }
    }
}