using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AlphaVantageClient
{
    public static class Register
    {
        public static IServiceCollection AddAlphaVantageStockClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AlphaVantageRequestHandler>((sp) =>
            {
                var configuration = sp.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                return new AlphaVantageRequestHandler(configuration.CurrentValue.ApiKey!);
            });
            services.AddHttpClient<IStockClient, StockClient>((serviceProvider, client) =>
            {
                var configuration = serviceProvider.GetRequiredService<IOptionsMonitor<AlphaVantageConfiguration>>();
                client.BaseAddress = new System.Uri(configuration.CurrentValue.BaseUrl);
            }).ConfigurePrimaryHttpMessageHandler<AlphaVantageRequestHandler>();
            services.AddSingleton<IValidateOptions<AlphaVantageConfiguration>, AlphaVantageConfigurationValidator>();
            services.AddOptions<AlphaVantageConfiguration>().Bind(configuration.GetSection("AlphaVantage"));
            services.AddAutoMapper(typeof(Register).Assembly);
            return services;
        }
    }
}