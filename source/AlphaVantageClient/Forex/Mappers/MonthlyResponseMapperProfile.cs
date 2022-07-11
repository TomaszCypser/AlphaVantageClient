using System;
using System.Collections.Generic;
using AlphaVantageClient.Forex.Serialization;
using AutoMapper;

namespace AlphaVantageClient.Forex.Mappers
{
    public class MonthlyResponseMapperProfile : Profile
    {
        public MonthlyResponseMapperProfile()
        {
            CreateMap<TimeSeriesApiResponse?, Models.MonthlyResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if (source is null) throw new ArgumentNullException(nameof(source));
                    if (source.MetaData is null) throw new ArgumentNullException(nameof(source.MetaData));
                    if (source.TimeSeries is null) throw new ArgumentNullException(nameof(source.TimeSeries));

                    return new Models.MonthlyResponse
                    (
                        context.Mapper.Map<MetaData, Models.MetaData>(source.MetaData),
                        context.Mapper.Map<Dictionary<string, TimeSeries>, Dictionary<string, Models.TimeSeries>>(source.TimeSeries)
                    );
                });

           
        }
    }
}