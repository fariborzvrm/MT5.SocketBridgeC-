using MT5Bridge.Core.Models.MarketData;

namespace MT5Bridge.Core.Clients
{
    public class MarketDataClient
    {
        private readonly SocketClient _socketClient;

        public MarketDataClient(SocketClient socketClient)
        {
            _socketClient = socketClient;
        }

        public TickData GetTickData(string symbol)
        {
            _socketClient.Send($"GET_TICK|{symbol}");
            string response = _socketClient.Receive();

            var parts = response.Split('|');
            if (parts.Length < 4)
                throw new InvalidOperationException("Invalid tick data response.");

            return new TickData(
                symbol,
                DateTime.Parse(parts[1]),
                double.Parse(parts[2]),
                double.Parse(parts[3])
            );
        }
    }
}
