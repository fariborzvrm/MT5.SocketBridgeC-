namespace MT5Bridge.Core.Models.Orders
{
    public enum OrderAction
    {
        Buy,
        Sell,
        BuyLimit,
        SellLimit,
        BuyStop,
        SellStop
    }

    public record OrderRequest(
        OrderAction Action,
        string Symbol,
        double Volume,
        double Price,
        double SL,
        double TP
    );
}
