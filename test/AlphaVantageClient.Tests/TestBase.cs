using System;
using System.IO;
using AlphaVantageClient.Cryptocurrency;
using AlphaVantageClient.Stock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlphaVantageClient
{
    public abstract class TestBase
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; }
        protected TestBase()
        {
            Configuration = CreateConfiguration();
            ServiceProvider = CreateServiceProvider(Configuration);
        }

        private static IConfigurationRoot CreateConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        private static IServiceProvider CreateServiceProvider(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddAlphaVantageStockClient(configuration, new StockHttpMessageHandlerStub());
            services.AddAlphaVantageCryptocurrencyClient(configuration, new CryptocurrencyHttpMessageHandlerStub());
            return services.BuildServiceProvider();
        }
    }
}