using System.Threading.Tasks;
using AlphaVantageClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlphaVantageClient.IntegrationTests;

public class StockClientTests : TestBase
{
    private readonly IStockClient _stockClient;

    public StockClientTests()
    {
        // Arrange
        _stockClient = ServiceProvider.GetRequiredService<IStockClient>();
    }

    [Theory]
    [InlineData(Interval.FifteenMinutes)]
    [InlineData(Interval.FiveMinutes)]
    [InlineData(Interval.OneMinute)]
    [InlineData(Interval.SixtyMinutes)]
    [InlineData(Interval.ThirtyMinutes)]
    public async Task GetIntradayTimeSeries_With_Interval_Parameter_Does_Not_Throw(Interval interval)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeries("IBM", interval);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GetIntradayTimeSeries_With_Adjusted_Parameter_Does_Not_Throw(bool adjusted)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeries("IBM", Interval.FifteenMinutes, adjusted);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetIntradayTimeSeries_With_OutputSize_Parameter_Does_Not_Throw(OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeries("IBM", Models.Interval.FifteenMinutes, true, outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetDailyTimeSeries_With_OutputSize_Parameter_Does_Not_Throw(OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetDailyTimeSeries("IBM", outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }

    [Theory]
    [InlineData(OutputSize.Compact)]
    [InlineData(OutputSize.Full)]
    public async Task GetDailyAdjustedTimeSeries_With_OutputSize_Parameter_Does_Not_Throw(OutputSize outputSize)
    {
        // Act 
        var result = await _stockClient.GetDailyAdjustedTimeSeries("IBM", outputSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }

    [Theory]
    [InlineData(Interval.FifteenMinutes)]
    [InlineData(Interval.FiveMinutes)]
    [InlineData(Interval.OneMinute)]
    [InlineData(Interval.SixtyMinutes)]
    [InlineData(Interval.ThirtyMinutes)]
    public async Task GetIntradayTimeSeriesExtendedHistory_With_Interval_Parameter_Does_Not_Throw(Interval interval)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeriesExtendedHistory("IBM", interval);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.IntradayExtendedHistoryTimeSeries);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GetIntradayTimeSeriesExtendedHistory_With_Adjusted_Parameter_Does_Not_Throw(bool adjusted)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeriesExtendedHistory("IBM", Interval.FifteenMinutes, adjusted);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.IntradayExtendedHistoryTimeSeries);
    }

    [Theory]
    [InlineData(Slice.Year1month1)]
    [InlineData(Slice.Year1month2)]
    [InlineData(Slice.Year1month3)]
    [InlineData(Slice.Year1month4)]
    [InlineData(Slice.Year1month5)]
    [InlineData(Slice.Year1month6)]
    [InlineData(Slice.Year1month7)]
    [InlineData(Slice.Year1month8)]
    [InlineData(Slice.Year1month9)]
    [InlineData(Slice.Year1month10)]
    [InlineData(Slice.Year1month11)]
    [InlineData(Slice.Year1month12)]
    [InlineData(Slice.Year2month1)]
    [InlineData(Slice.Year2month2)]
    [InlineData(Slice.Year2month3)]
    [InlineData(Slice.Year2month4)]
    [InlineData(Slice.Year2month5)]
    [InlineData(Slice.Year2month6)]
    [InlineData(Slice.Year2month7)]
    [InlineData(Slice.Year2month8)]
    [InlineData(Slice.Year2month9)]
    [InlineData(Slice.Year2month10)]
    [InlineData(Slice.Year2month11)]
    [InlineData(Slice.Year2month12)]
    public async Task GetIntradayTimeSeriesExtendedHistory_With_Slice_Parameter_Does_Not_Throw(Slice slice)
    {
        // Act 
        var result = await _stockClient.GetIntradayTimeSeriesExtendedHistory("IBM", Interval.FifteenMinutes, true, slice);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.IntradayExtendedHistoryTimeSeries);
    }

    [Fact]
    public async Task GetMonthlyAdjustedTimeSeries_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.GetMonthlyAdjustedTimeSeries("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }
    
    [Fact]
    public async Task GetMonthlyTimeSeries_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.GetMonthlyTimeSeries("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }
    
    [Fact]
    public async Task GetWeeklyAdjustedTimeSeries_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.GetWeeklyAdjustedTimeSeries("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }
    
    [Fact]
    public async Task GetWeeklyTimeSeries_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.GetWeeklyTimeSeries("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MetaData);
        Assert.NotNull(result.TimeSeries);
    }
    
    [Fact]
    public async Task GetQuote_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.GetQuote("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.GlobalQuote);
    }
    
    [Fact]
    public async Task Search_Does_Not_Throw()
    {
        // Act 
        var result = await _stockClient.SearchSymbol("IBM");

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.BestMatches);
    }
}