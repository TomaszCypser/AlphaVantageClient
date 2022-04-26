namespace AlphaVantageClient.Models
{
    public class QuoteResponse
    {
        public QuoteResponse(GlobalQuote globalQuote)
        {
            GlobalQuote = globalQuote;
        }

        public GlobalQuote GlobalQuote { get;  }
    }

    public class GlobalQuote
    {
        public GlobalQuote(string symbol, decimal open, decimal high, decimal low, decimal price, long volume, string latestTradingDay, decimal previousClose, decimal change, string changePercent)
        {
            Symbol = symbol;
            Open = open;
            High = high;
            Low = low;
            Price = price;
            Volume = volume;
            LatestTradingDay = latestTradingDay;
            PreviousClose = previousClose;
            Change = change;
            ChangePercent = changePercent;
        }

        public string Symbol { get;  }
        public decimal Open { get;  }
        public decimal High { get;  }
        public decimal Low { get;  }
        public decimal Price { get;  }
        public long Volume { get;  }
        public string LatestTradingDay { get;  }
        public decimal PreviousClose { get;  }
        public decimal Change { get;  }
        public string ChangePercent { get;  }
    }
}