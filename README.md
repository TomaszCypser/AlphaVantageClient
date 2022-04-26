<h1 align="center">
  AlphaVantageClient
  <br>
</h1>

## Table of contents <!-- omit in toc -->

- [Introduction](#introduction)
- [Usage](#usage)

## Introduction

AlphaVantageClient is a simple C# .Net library to access https://www.alphavantage.co/ stock APIs. 

Supported:

- :white_check_mark: Core Stock APIs
- :x: Fundamental Data
- :x: Forex (FX)
- :x: Cryptocurrencies
- :x: Economic Indicators
- :x: Technical Indicators

## Usage

The following example is demonstrating how one would call `TIME_SERIES_INTRADAY` endpoint using this library.

Configuration located in `appsettings.json`

```json
// Don't specify credentials in source code, this is for demo only!
{
    "AlphaVantage": {
          "BaseUrl": "https://www.alphavantage.co/",
          "ApiKey": "#PLACEHOLDER#"
      }
  }
```

ServiceCollection setup for dependency injection.

```csharp
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
```

```csharp
    var configuration = SetupConfiguration();
    var serviceProvider = ConfigureServices(configuration);
    var stockClient = serviceProvider.GetRequiredService<IStockClient>();
    var result = stockClient.GetIntradayTimeSeries("IBM", Interval.OneMinute).GetAwaiter().GetResult();
    System.Console.WriteLine(JsonSerializer.Serialize(result));    
```