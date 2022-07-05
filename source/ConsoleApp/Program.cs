using System;
using System.Text.Json;
using AlphaVantageClient;
using AlphaVantageClient.Stock;
using AlphaVantageClient.Stock.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = SetupConfiguration();
            var serviceProvider = ConfigureServices(configuration);
            var stockClient = serviceProvider.GetRequiredService<IStockClient>();
            var result = stockClient.GetIntradayTimeSeries("IBM",Interval.FifteenMinutes).GetAwaiter().GetResult();
            System.Console.WriteLine(JsonSerializer.Serialize(result));
        }

        private static IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddAlphaVantageStockClient(configuration);
            return services.BuildServiceProvider();
        }

        private static IConfiguration SetupConfiguration()
            => new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();            
    }
}