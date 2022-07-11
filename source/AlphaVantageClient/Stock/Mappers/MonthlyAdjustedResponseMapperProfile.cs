using System;
using System.Collections.Generic;
using AlphaVantageClient.Stock.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Stock.Mappers
{
    public class MonthlyAdjustedResponseMapperProfile : Profile
    {
        public MonthlyAdjustedResponseMapperProfile()
        {
            CreateMap<TimeSeriesApiResponse?, Models.MonthlyAdjustedResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.MonthlyAdjustedResponse
                    (
                        context.Mapper.Map<Serialization.MetaData, Models.MetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.AdjustedTimeSeries>>(source.TimeSeries)
                    );
                });
        }
    }
}