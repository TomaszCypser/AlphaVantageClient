using System.ComponentModel;
using System.Threading.Tasks;
using AlphaVantageClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlphaVantageClient.Forex;

[Category("IntegrationTest")]
public class ForexClientTests : TestBase
{
    private readonly IForexClient _forexClient;

    public ForexClientTests()
    {
        // Arrange
        _forexClient = ServiceProvider.GetRequiredService<IForexClient>();
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetIntradayTimeSeries_Returns_Expected_Result(OutputSize outputSize)
    {
        // Act 
        var result = await _forexClient.GetIntradayTimeSeries("EUR", "USD", Interval.FiveMinutes, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("FX Intraday (5min) Time Series", result.MetaData.Information);
        Assert.Equal("EUR", result.MetaData.FromSymbol);
        Assert.Equal("USD", result.MetaData.ToSymbol);
        Assert.Equal("5min", result.MetaData.Interval);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.NotEmpty(result.TimeSeries);
        if (outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetDailyTimeSeries_Returns_Expected_Result(OutputSize outputSize)
    {
        // Act 
        var result = await _forexClient.GetDailyTimeSeries("EUR", "USD", outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Forex Daily Prices (open, high, low, close)", result.MetaData.Information);
        Assert.Equal("EUR", result.MetaData.FromSymbol);
        Assert.Equal("USD", result.MetaData.ToSymbol);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.NotEmpty(result.TimeSeries);
        if (outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Fact]
    public async Task GetMonthlyTimeSeries_Returns_Expected_Result()
    {
        // Act 
        var result = await _forexClient.GetMonthlyTimeSeries("EUR", "USD");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Forex Monthly Prices (open, high, low, close)", result.MetaData.Information);
        Assert.Equal("EUR", result.MetaData.FromSymbol);
        Assert.Equal("USD", result.MetaData.ToSymbol);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 30);
    }

    [Fact]
    public async Task GetWeeklyTimeSeries_Returns_Expected_Result()
    {
        // Act 
        var result = await _forexClient.GetWeeklyTimeSeries("EUR", "USD");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Forex Weekly Prices (open, high, low, close)", result.MetaData.Information);
        Assert.Equal("EUR", result.MetaData.FromSymbol);
        Assert.Equal("USD", result.MetaData.ToSymbol);
        Assert.Equal("UTC", result.MetaData.TimeZone);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("BTC", "CNY")]
    [InlineData("USD", "JPY")]
    public async Task GetCurrencyExchangeRate_Returns_Expected_Result(string fromCurrency, string toCurrency)
    {
        // Act 
        var result = await _forexClient.GetCurrencyExchangeRate(fromCurrency, toCurrency);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.RealTimeExchangeRate);
        Assert.Equal(fromCurrency, result.RealTimeExchangeRate.FromCurrencyCode);
        Assert.Equal(toCurrency, result.RealTimeExchangeRate.ToCurrencyCode);
        Assert.Equal("UTC", result.RealTimeExchangeRate.Timezone);
    }
}