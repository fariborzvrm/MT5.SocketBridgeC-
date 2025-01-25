using MT5Bridge.Core.Clients;
using MT5Bridge.Core.Models.MarketData;

namespace MT5Bridge.DemoApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                using var socket = new SocketClient("127.0.0.1", 5000, "MT5SECURE123");
                socket.Connect();

                var marketData = new MarketDataClient(socket);
                TickData eurusdTick = marketData.GetTickData("EURUSD");
                Console.WriteLine($"EURUSD Tick: {eurusdTick.Bid}/{eurusdTick.Ask}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
