using System;
using System.Collections.Generic;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Forex.Mappers
{
    public class WeeklyResponseMapperProfile : Profile
    {
        public WeeklyResponseMapperProfile()
        {
            CreateMap<TimeSeriesApiResponse?, Models.WeeklyResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if(source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));
                    
                    return new Models.WeeklyResponse
                    (
                        context.Mapper.Map<MetaData, Models.MetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.TimeSeries>>(source.TimeSeries)
                    );
                });
        }
    }
}