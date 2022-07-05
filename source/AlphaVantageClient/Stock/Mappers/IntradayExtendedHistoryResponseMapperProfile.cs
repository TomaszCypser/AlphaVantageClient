using System;
using System.Collections.Generic;
using AutoMapper;

namespace AlphaVantageClient.Stock.Mappers
{
    public class IntradayExtendedHistoryResponseMapperProfile : Profile
    {
        public IntradayExtendedHistoryResponseMapperProfile()
        {
            CreateMap<IEnumerable<Serialization.IntradayExtendedHistoryApiResponse>?, Models.IntradayExtendedHistoryResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));

                    return new Models.IntradayExtendedHistoryResponse
                    (
                        context.Mapper.Map<IEnumerable<Serialization.IntradayExtendedHistoryApiResponse>, List<Models.IntradayExtendedHistoryTimeSeries>>(source)
                    );
                });

            CreateMap<Serialization.IntradayExtendedHistoryApiResponse, Models.IntradayExtendedHistoryTimeSeries>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.Time)) throw new ArgumentException($"Provided value for {nameof(source.Time)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Close)) throw new ArgumentException($"Provided value for {nameof(source.Close)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Close, out decimal closeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Close)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Volume)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} cannot be null or empty.");
                    if(!Int64.TryParse(source.Volume, out long volumeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} is not a valid number.");

                    return new Models.IntradayExtendedHistoryTimeSeries
                    (
                        source.Time,
                        openConverted,
                        highConverted,
                        lowConverted,
                        closeConverted,
                        volumeConverted
                    );
                });
        }
    }
}