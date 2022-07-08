using System.ComponentModel;
using System.Threading.Tasks;
using AlphaVantageClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlphaVantageClient.Cryptocurrency;

[Category("IntegrationTest")]
public class CryptoCurrencyClientTests : TestBase
{
    private readonly ICryptocurrencyClient _cryptocurrencyClient;

    public CryptoCurrencyClientTests()
    {
        // Arrange
        _cryptocurrencyClient = ServiceProvider.GetRequiredService<ICryptocurrencyClient>();
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetIntradayTimeSeries_Returns_Expected_Result(OutputSize outputSize)
    {
        // Act 
        var result = await _cryptocurrencyClient.GetIntradayTimeSeries("ETH", "USD", Interval.FiveMinutes, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Crypto Intraday (5min) Time Series", result.MetaData.Information);
        Assert.Equal("ETH", result.MetaData.DigitalCurrencyCode);
        Assert.Equal("Ethereum", result.MetaData.DigitalCurrencyName);
        Assert.Equal("5min", result.MetaData.Interval);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.Equal("USD", result.MetaData.MarketCode);
        Assert.Equal("United States Dollar", result.MetaData.MarketName);
        Assert.NotEmpty(result.TimeSeries);
        if (outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Fact]
    public async Task GetDailyTimeSeries_Returns_Expected_Result()
    {
        // Act 
        var result = await _cryptocurrencyClient.GetDailyTimeSeries("BTC", "CNY");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Daily Prices and Volumes for Digital Currency", result.MetaData.Information);
        Assert.Equal("BTC", result.MetaData.DigitalCurrencyCode);
        Assert.Equal("Bitcoin", result.MetaData.DigitalCurrencyName);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.Equal("CNY", result.MetaData.MarketCode);
        Assert.Equal("Chinese Yuan", result.MetaData.MarketName);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }

    [Fact]
    public async Task GetMonthlyTimeSeries_Returns_Expected_Result()
    {
        // Act 
        var result = await _cryptocurrencyClient.GetMonthlyTimeSeries("BTC", "CNY");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Monthly Prices and Volumes for Digital Currency", result.MetaData.Information);
        Assert.Equal("BTC", result.MetaData.DigitalCurrencyCode);
        Assert.Equal("Bitcoin", result.MetaData.DigitalCurrencyName);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.Equal("CNY", result.MetaData.MarketCode);
        Assert.Equal("Chinese Yuan", result.MetaData.MarketName);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 30);
    }

    [Fact]
    public async Task GetWeeklyTimeSeries_Returns_Expected_Result()
    {
        // Act 
        var result = await _cryptocurrencyClient.GetWeeklyTimeSeries("BTC", "CNY");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Weekly Prices and Volumes for Digital Currency", result.MetaData.Information);
        Assert.Equal("BTC", result.MetaData.DigitalCurrencyCode);
        Assert.Equal("Bitcoin", result.MetaData.DigitalCurrencyName);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.Equal("CNY", result.MetaData.MarketCode);
        Assert.Equal("Chinese Yuan", result.MetaData.MarketName);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("BTC", "CNY")]
    [InlineData("USD", "JPY")]
    public async Task GetCurrencyExchangeRate_Returns_Expected_Result(string fromCurrency, string toCurrency)
    {
        // Act 
        var result = await _cryptocurrencyClient.GetCurrencyExchangeRate(fromCurrency, toCurrency);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.RealTimeExchangeRate);
        Assert.Equal(fromCurrency, result.RealTimeExchangeRate.FromCurrencyCode);
        Assert.Equal(toCurrency, result.RealTimeExchangeRate.ToCurrencyCode);
        Assert.Equal("UTC", result.RealTimeExchangeRate.Timezone);
    }
}