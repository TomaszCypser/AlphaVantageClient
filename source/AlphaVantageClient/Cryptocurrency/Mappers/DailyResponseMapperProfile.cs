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
                        context.Mapper.Map<Serialization.MetaData, Models.MetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, Serialization.TimeSeries>, Dictionary<string, Models.ExtendedTimesSeries>>(source.TimeSeries)
                    );
                });
        }
    }
}