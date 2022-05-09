using System;
using AutoMapper;

namespace AlphaVantageClient.Mappers
{
    public class SearchResponseMapperProfile : Profile
    {
        public SearchResponseMapperProfile()
        {
            CreateMap<Serialization.SearchApiResponse?, Models.SearchResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(source.BestMatches is null) throw new ArgumentNullException(nameof(source.BestMatches));

                    return new Models.SearchResponse
                    (
                        context.Mapper.Map<Serialization.BestMatches[], Models.BestMatches[]>(source.BestMatches)
                    );
                });

            CreateMap<Serialization.BestMatches, Models.BestMatches>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConvertUsing((source, dest, context) =>
                {
                    if(source is null) throw new ArgumentNullException(nameof(source));
                    if(string.IsNullOrEmpty(source.Currency)) throw new ArgumentException($"Provided value for {nameof(source.Currency)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketClose)) throw new ArgumentException($"Provided value for {nameof(source.MarketClose)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MarketOpen)) throw new ArgumentException($"Provided value for {nameof(source.MarketOpen)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Name)) throw new ArgumentException($"Provided value for {nameof(source.Name)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Region)) throw new ArgumentException($"Provided value for {nameof(source.Region)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Symbol)) throw new ArgumentException($"Provided value for {nameof(source.Symbol)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.TimeZone)) throw new ArgumentException($"Provided value for {nameof(source.TimeZone)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.Type)) throw new ArgumentException($"Provided value for {nameof(source.Type)} cannot be null or empty.");
                    if(string.IsNullOrEmpty(source.MatchScore)) throw new ArgumentException($"Provided value for {nameof(source.MatchScore)} cannot be null or empty.");
                    if(!Decimal.TryParse(source.MatchScore, out decimal matchScoreConverted)) throw new ArgumentException($"Provided value for {nameof(source.MatchScore)} is not a valid number.");

                    return new Models.BestMatches
                    (
                        source.Symbol,
                        source.Name,
                        source.Type,
                        source.Region,
                        source.MarketOpen,
                        source.MarketClose,
                        source.TimeZone,
                        source.Currency,
                        matchScoreConverted
                    );
                });
        }
    }
}