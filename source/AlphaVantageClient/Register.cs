using System.Net.Http;
using AlphaVantageClient.Cryptocurrency;
using AlphaVantageClient.Forex;
using AlphaVantageClient.Stock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AlphaVantageClient
{
    public static class Register
    {
        public static IServiceCollection AddAlphaVantageStockClient(this IServiceCollection services, IConfiguration configuration)
            => AddAlphaVantageStockClient(services, configuration, new HttpClientHandler());
        public static IServiceCollection AddAlphaVantageCryptocurrencyClient(this IServiceCollection services, IConfiguration configuration)
            => AddAlphaVantageCryptocurrencyClient(services, configuration, new HttpClientHandler());
        public static IServiceCollection AddAlphaVantageForexClient(this IServiceCollection services, IConfiguration configuration)
            => AddAlphaVantageForexClient(services, configuration, new HttpClientHandler());
        
        public static IServiceCollection AddAlphaVantageCryptocurrencyClient(
            this IServiceCollection services, 
            IConfiguration configuration, 
            HttpMessageHandler httpMessageHandler)
            => AddAlphaVantageClient<ICryptocurrencyClient, CryptocurrencyClient>(services, configuration, httpMessageHandler); 
        
        public static IServiceCollection AddAlphaVantageForexClient(
            this IServiceCollection services, 
            IConfiguration configuration, 
            HttpMessageHandler httpMessageHandler)
            => AddAlphaVantageClient<IForexClient, ForexClient>(services, configuration, httpMessageHandler);

        
        public static IServiceCollection AddAlphaVantageStockClient(
            this IServiceCollection services, 
            IConfiguration configuration, 
            HttpMessageHandler httpMessageHandler)
            => AddAlphaVantageClient<IStockClient, StockClient>(services, configuration, httpMessageHandler);
        
        private static IServiceCollection AddAlphaVantageClient<TClientInterface,TClient>(
            this IServiceCollection services, 
            IConfiguration configuration, 
            HttpMessageHandler httpMessageHandler)
            where TClientInterface : class
            where TClient : AlphaVantageBaseClient, TClientInterface
        {
            services.AddTransient(sp =>
            {
                var alphaVantageConfiguration = sp.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                return new AlphaVantageRequestHandler(alphaVantageConfiguration.CurrentValue.ApiKey!);
            });
            services.AddHttpClient<TClientInterface, TClient>((serviceProvider, client) =>
            {
                var alphaVantageConfiguration =
                    serviceProvider.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                client.BaseAddress = new System.Uri(alphaVantageConfiguration.CurrentValue.BaseUrl!);
            }).ConfigurePrimaryHttpMessageHandler(sp =>
            {
                var alphaVantageConfiguration = sp.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                return new AlphaVantageRequestHandler(httpMessageHandler, alphaVantageConfiguration.CurrentValue.ApiKey!);
            });
            services.AddSingleton<IValidateOptions<AlphaVantageConfiguration>, AlphaVantageConfigurationValidator>();
            services.AddOptions<AlphaVantageConfiguration>().Bind(configuration.GetSection("AlphaVantage"));
            services.AddAutoMapper(typeof(Register).Assembly);
            return services;
        }
    }
}