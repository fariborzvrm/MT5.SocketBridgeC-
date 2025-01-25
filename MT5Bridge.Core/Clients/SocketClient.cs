using System;
using System.Net.Sockets;
using System.Text;

namespace MT5Bridge.Core.Clients
{
    public class SocketClient : IDisposable
    {
        private TcpClient? _client; // Nullable to avoid warnings
        private NetworkStream? _stream; // Nullable to avoid warnings
        private readonly string _host;
        private readonly int _port;
        private readonly string _authToken;

        public SocketClient(string host, int port, string authToken)
        {
            _host = host;
            _port = port;
            _authToken = authToken;
        }

        public void Connect()
        {
            _client = new TcpClient();
            _client.Connect(_host, _port);
            _stream = _client.GetStream();

            Send($"AUTH|{_authToken}");
            var response = Receive();
            if (!response.StartsWith("AUTH|SUCCESS"))
                throw new AuthenticationException("Connection authentication failed");
        }

        public void Send(string command)
        {
            if (_stream == null)
                throw new InvalidOperationException("Stream is not initialized.");

            byte[] data = Encoding.ASCII.GetBytes(command);
            _stream.Write(data, 0, data.Length);
        }

        public string Receive()
        {
            if (_stream == null)
                throw new InvalidOperationException("Stream is not initialized.");

            byte[] buffer = new byte[4096];
            int bytesRead = _stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }

        public void Dispose()
        {
            _stream?.Close();
            _client?.Close();
        }
    }

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }
}
