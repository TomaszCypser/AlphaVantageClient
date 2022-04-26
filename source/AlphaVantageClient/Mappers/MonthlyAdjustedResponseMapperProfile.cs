using System;
using System.Collections.Generic;
using AlphaVantageClient.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Mappers
{
    public class MonthlyAdjustedResponseMapperProfile : Profile
    {
        public MonthlyAdjustedResponseMapperProfile()
        {
            CreateMap<StockTimeSeriesApiResponse?, Models.MonthlyAdjustedResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.MonthlyAdjustedResponse
                    (
                        context.Mapper.Map<Serialization.MetaData, Models.MonthlyAdjustedMetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.MonthlyAdjustedTimeSeries>>(source.TimeSeries)
                    );
                });

            CreateMap<Serialization.MetaData, Models.MonthlyAdjustedMetaData>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LastRefreshed)) throw new ArgumentException($"Provided value for {nameof(source.LastRefreshed)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Information)) throw new ArgumentException($"Provided value for {nameof(source.Information)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Symbol)) throw new ArgumentException($"Provided value for {nameof(source.Symbol)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");
                    
                    return new Models.MonthlyAdjustedMetaData
                    (
                        source.Information,
                        source.Symbol,
                        source.LastRefreshed,
                        source.TimeZone
                    );
                });

            CreateMap<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.MonthlyAdjustedTimeSeries>>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    var mappedResponse =  new Dictionary<string, Models.MonthlyAdjustedTimeSeries>();
                    foreach(var item in source)
                    {
                        mappedResponse.Add(
                            item.Key,
                            context.Mapper.Map<Serialization.TimeSeries, Models.MonthlyAdjustedTimeSeries>(item.Value)
                            );
                    }
                    return mappedResponse;
                });

            CreateMap<Serialization.TimeSeries, Models.MonthlyAdjustedTimeSeries>()
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

                    return new Models.MonthlyAdjustedTimeSeries
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