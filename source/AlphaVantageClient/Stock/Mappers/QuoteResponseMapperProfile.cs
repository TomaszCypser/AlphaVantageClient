using System;
using AutoMapper;

namespace AlphaVantageClient.Stock.Mappers
{
    public class QuoteResponseMapperProfile : Profile
    {
        public QuoteResponseMapperProfile()
        {
            CreateMap<Serialization.QuoteApiResponse?, Models.QuoteResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.GlobalQuote is null) throw new ArgumentNullException(nameof(source.GlobalQuote));

                    return new Models.QuoteResponse
                    (
                        context.Mapper.Map<Serialization.GlobalQuote, Models.GlobalQuote>(source.GlobalQuote)
                    );
                });

            CreateMap<Serialization.GlobalQuote, Models.GlobalQuote>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.LatestTradingDay)) throw new ArgumentException($"Provided value for {nameof(source.LatestTradingDay)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Symbol)) throw new ArgumentException($"Provided value for {nameof(source.Symbol)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.ChangePercent)) throw new ArgumentException($"Provided value for {nameof(source.ChangePercent)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Change)) throw new ArgumentException($"Provided value for {nameof(source.Change)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Change, out decimal changeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Change)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Price)) throw new ArgumentException($"Provided value for {nameof(source.Price)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Price, out decimal priceConverted)) throw new ArgumentException($"Provided value for {nameof(source.Price)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.PreviousClose)) throw new ArgumentException($"Provided value for {nameof(source.PreviousClose)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.PreviousClose, out decimal previousCloseConverted)) throw new ArgumentException($"Provided value for {nameof(source.PreviousClose)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.High)) throw new ArgumentException($"Provided value for {nameof(source.High)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.High, out decimal highConverted)) throw new ArgumentException($"Provided value for {nameof(source.High)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Low)) throw new ArgumentException($"Provided value for {nameof(source.Low)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Low, out decimal lowConverted)) throw new ArgumentException($"Provided value for {nameof(source.Low)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Open)) throw new ArgumentException($"Provided value for {nameof(source.Open)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.Open, out decimal openConverted)) throw new ArgumentException($"Provided value for {nameof(source.Open)} is not a valid number.");
                    if(string.IsNullOrEmpty(source.Volume)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} cannot be null or empty.");
                    if(!Int64.TryParse(source.Volume, out long volumeConverted)) throw new ArgumentException($"Provided value for {nameof(source.Volume)} is not a valid number.");

                    return new Models.GlobalQuote
                    (
                        source.Symbol,
                        openConverted,
                        highConverted,
                        lowConverted,
                        priceConverted,
                        volumeConverted,
                        source.LatestTradingDay,
                        previousCloseConverted,
                        changeConverted,
                        source.ChangePercent
                    );
                });
        }
    }
}