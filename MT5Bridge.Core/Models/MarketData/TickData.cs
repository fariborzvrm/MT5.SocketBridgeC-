using System;

namespace MT5Bridge.Core.Models.MarketData
{
    public record TickData(
        string Symbol,
        DateTime Timestamp,
        double Bid,
        double Ask
    );
}
