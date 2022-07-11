using System.ComponentModel;
using System.Threading.Tasks;
using AlphaVantageClient.Models;
using AlphaVantageClient.Stock.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlphaVantageClient.Stock;

[Category("IntegrationTest")]
public class StockClientTests : TestBase
{
    private readonly IStockClient _stockClient;

    public StockClientTests()
    {
        // Arrange
        _stockClient = ServiceProvider.GetRequiredService<IStockClient>();
    }

    [Theory]
    [InlineData(Interval.FiveMinutes, OutputSize.Compact)]
    [InlineData(Interval.FiveMinutes, OutputSize.Full)]
    public async Task GetIntradayTimeSeries_Returns_Expected_Result(Interval interval, OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeries("IBM", interval, true, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Intraday (5min) open, high, low, close prices and volume",result.MetaData.Information);
        Assert.Equal("IBM",result.MetaData.Symbol);
        Assert.Equal("5min",result.MetaData.Interval);
        Assert.Equal("US/Eastern",result.MetaData.TimeZone);
        Assert.NotEmpty(result.TimeSeries);
        if(outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Theory]
    [InlineData("IBM", OutputSize.Compact)]
    [InlineData("IBM", OutputSize.Full)]
    [InlineData("TSCO.LON", OutputSize.Full)]
    [InlineData("SHOP.TRT", OutputSize.Full)]
    [InlineData("GPV.TRV", OutputSize.Full)]
    [InlineData("DAI.DEX", OutputSize.Full)]
    [InlineData("RELIANCE.BSE", OutputSize.Full)]
    [InlineData("600104.SHH", OutputSize.Full)]
    [InlineData("000002.SHZ", OutputSize.Full)]
    public async Task GetDailyTimeSeries_Returns_Expected_Result(string symbol, OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetDailyTimeSeries(symbol, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Daily Prices (open, high, low, close) and Volumes",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        if(outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Theory]
    [InlineData("IBM", OutputSize.Compact)]
    [InlineData("IBM", OutputSize.Full)]
    [InlineData("TSCO.LON", OutputSize.Full)]
    [InlineData("SHOP.TRT", OutputSize.Full)]
    [InlineData("GPV.TRV", OutputSize.Full)]
    [InlineData("DAI.DEX", OutputSize.Full)]
    [InlineData("RELIANCE.BSE", OutputSize.Full)]
    [InlineData("600104.SHH", OutputSize.Full)]
    [InlineData("000002.SHZ", OutputSize.Full)]
    public async Task GetDailyAdjustedTimeSeries_Returns_Expected_Result(string symbol, OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetDailyAdjustedTimeSeries(symbol, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Daily Time Series with Splits and Dividend Events",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        if(outputSize == OutputSize.Compact) Assert.Equal(100, result.TimeSeries.Count);
        else Assert.True(result.TimeSeries.Count > 100);
    }

    [Theory]
    [InlineData(Interval.FifteenMinutes, Slice.Year1month1, true)]
    [InlineData(Interval.FifteenMinutes, Slice.Year1month2, true)]
    [InlineData(Interval.SixtyMinutes, Slice.Year1month1, false)]
    public async Task GetIntradayTimeSeriesExtendedHistory_Returns_Expected_Result(Interval interval, Slice slice, bool adjusted)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeriesExtendedHistory("IBM", interval, adjusted, slice);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.IntradayExtendedHistoryTimeSeries);
        Assert.True(result.IntradayExtendedHistoryTimeSeries.Count > 100);
    }

    [Theory]
    [InlineData("IBM")]
    [InlineData("TSCO.LON")]
    public async Task GetMonthlyAdjustedTimeSeries_Returns_Expected_Result(string symbol)
    {
        // Act 
        var result = await _stockClient.GetMonthlyAdjustedTimeSeries(symbol);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Monthly Adjusted Prices and Volumes",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("IBM")]
    [InlineData("TSCO.LON")]
    public async Task GetMonthlyTimeSeries_Returns_Expected_Result(string symbol)
    {
        // Act 
        var result = await _stockClient.GetMonthlyTimeSeries(symbol);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Monthly Prices (open, high, low, close) and Volumes",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("IBM")]
    [InlineData("TSCO.LON")]
    public async Task GetWeeklyAdjustedTimeSeries_Returns_Expected_Result(string symbol)
    {
        // Act 
        var result = await _stockClient.GetWeeklyAdjustedTimeSeries(symbol);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Weekly Adjusted Prices and Volumes",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("IBM")]
    [InlineData("TSCO.LON")]
    public async Task GetWeeklyTimeSeries_Returns_Expected_Result(string symbol)
    {
        // Act 
        var result = await _stockClient.GetWeeklyTimeSeries(symbol);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.Equal("Weekly Prices (open, high, low, close) and Volumes",result.MetaData.Information);
        Assert.Equal(symbol ,result.MetaData.Symbol);
        Assert.NotEmpty(result.TimeSeries);
        Assert.True(result.TimeSeries.Count > 100);
    }
    
    [Theory]
    [InlineData("IBM")]
    [InlineData("300135.SHZ")]
    public async Task GetQuote_Returns_Expected_Result(string symbol)
    {
        // Act 
        var result = await _stockClient.GetQuote(symbol);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.GlobalQuote);
    }
    
    [Theory]
    [InlineData("tesco", "Tesco PLC")]
    [InlineData("tencent", "Tencent Holdings Ltd")]
    [InlineData("BA", "Boeing Company")]
    [InlineData("SAIC", "Science Applications International Corp")]
    public async Task Search_Returns_Expected_Result(string keywords, string expectedMatchName)
    {
        // Act 
        var result = await _stockClient.SearchSymbol(keywords);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.BestMatches);
        Assert.Contains(result.BestMatches!, x => x.Name == expectedMatchName);
    }
}