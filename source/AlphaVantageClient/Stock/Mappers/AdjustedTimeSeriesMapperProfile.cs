using System;
using System.Collections.Generic;
using AlphaVantageClient.Stock.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Stock.Mappers
{
    public class AdjustedTimeSeriesMapperProfile : Profile
    {
        public AdjustedTimeSeriesMapperProfile()
        {
            CreateMap<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.AdjustedTimeSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse =  new Dictionary<string, Models.AdjustedTimeSeries>();
                    foreach(var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<Serialization.TimeSeries, Models.AdjustedTimeSeries>(item.Value)
                            );
                    }
                    return mappedResponse;
                });

            CreateMap<Serialization.TimeSeries, Models.AdjustedTimeSeries>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.AdjustedClose)) throw new ArgumentException($"Provided value for {nameof(source.AdjustedClose)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.AdjustedClose, out decimal adjustedCloseConverted)) throw new ArgumentException($"Provided value for {nameof(source.AdjustedClose)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Close)) throw new ArgumentException($"Provided value for {nameof(source.Close)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Close, out decimal closeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Close)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.DividendAmount)) throw new ArgumentException($"Provided value for {nameof(source.DividendAmount)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.DividendAmount, out decimal dividendAmountConverted)) throw new ArgumentException($"Provided value for {nameof(source.DividendAmount)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Volume)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} cannot be null or empty.");
                    if(!Int64.TryParse(source.Volume, out long volumeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} is not a valid number.");

                    return new Models.AdjustedTimeSeries
                    (
                        openConverted,
                        highConverted,
                        lowConverted,
                        closeConverted,
                        adjustedCloseConverted,
                        dividendAmountConverted,
                        volumeConverted
                    );
                });
        }
    }
}