using System;
using System.Collections.Generic;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Forex.Mappers
{
    public class TimeSeriesMapperProfile : Profile
    {
        public TimeSeriesMapperProfile()
        {
            CreateMap<Dictionary<string, TimeSeries>, Dictionary<string, Models.TimeSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if (source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse = new Dictionary<string, Models.TimeSeries>();
                    foreach (var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<TimeSeries, Models.TimeSeries>(item.Value)
                        );
                    }

                    return mappedResponse;
                });

            CreateMap<TimeSeries, Models.TimeSeries>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if (source is null) throw new ArgumentNullException(nameof(source));
                    if (string.IsNullOrEmpty(source.Close)) throw new ArgumentException($"Provided value for {nameof(source.Close)} cannot be null or empty.");
                    if (!decimal.TryParse(source.Close, out decimal closeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Close)} is not a valid number.");
                    if (string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if (!decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if (string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if (!decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if (string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if (!decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");

                    return new Models.TimeSeries
                    (
                        openConverted,
                        highConverted,
                        lowConverted,
                        closeConverted
                    );
                });
        }
    }
}