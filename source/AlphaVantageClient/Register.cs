using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AlphaVantageClient
{
    public static class Register
    {
        public static IServiceCollection AddAlphaVantageStockClient(this IServiceCollection services, IConfiguration configuration)
        {
            return AddAlphaVantageStockClient(services, configuration, new HttpClientHandler());
        }
        
        public static IServiceCollection AddAlphaVantageStockClient(
            this IServiceCollection services, 
            IConfiguration configuration, 
            HttpMessageHandler httpMessageHandler)
        {
            services.AddTransient<AlphaVantageRequestHandler>((sp) =>
            {
                var alphaVantageConfiguration = sp.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                return new AlphaVantageRequestHandler(alphaVantageConfiguration.CurrentValue.ApiKey!);
            });
            services.AddHttpClient<IStockClient, StockClient>((serviceProvider, client) =>
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