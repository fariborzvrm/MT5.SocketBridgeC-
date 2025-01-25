
```markdown
# MT5Bridge Project

MT5Bridge is a project that connects MetaTrader 5 (MT5) trading platform with a .NET-based server. The server allows you to send and receive market data, orders, and account information between the trading platform (MT5) and external applications or services. This bridge is designed to enable interaction between the trading platform and other software, allowing for automated trading, data analysis, and other functionalities.

## Table of Contents

- [Overview](#overview)
- [Modules](#modules)
  - [MT5Bridge.Core](#mt5bridgecore)
  - [MT5Bridge.DemoApp](#mt5bridgedemoapp)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Running the Project](#running-the-project)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Overview

MT5Bridge serves as a communication bridge between the MetaTrader 5 platform and a custom-built .NET application. This solution is designed for traders, developers, or institutions looking to integrate trading strategies or external data into their MT5 setup, or to build custom automation for trade execution, order management, and account tracking.

## Modules

The project is split into two main modules:

### MT5Bridge.Core

`MT5Bridge.Core` is the core library that handles the connection and communication between the C# application and MetaTrader 5 (MT5). It is responsible for managing socket communication, market data collection, order management, and account information exchange.

Key Components:
- **SocketClient**: A TCP client that listens for connections from MT5 and sends/receives data over a network socket.
- **MarketDataClient**: A component responsible for fetching real-time market data such as prices and order book data.
- **OrderClient**: Manages sending and receiving order-related commands to MT5, including creating, modifying, and closing orders.
- **AccountClient**: Retrieves account balance, equity, margin, and other account-related details.
- **Exceptions**: Handles exceptions and errors in socket connections, market data, and order management.

### MT5Bridge.DemoApp

`MT5Bridge.DemoApp` is a console application that demonstrates how to use `MT5Bridge.Core` in a real-world scenario. It connects to the MT5 trading platform via a TCP socket, subscribes to market data, and places orders.

Key Features:
- **Socket Initialization**: Establishes a connection to the MT5 platform and handles communication.
- **Order Execution**: Sends trade orders to MT5 and manages trade results.
- **Market Data Subscription**: Subscribes to price updates and retrieves real-time market data.

## Getting Started

To get started with MT5Bridge, follow these steps:

### Prerequisites

Ensure you have the following installed on your system:

- **.NET SDK** (at least version 6.0)
  - Download from [here](https://dotnet.microsoft.com/download/dotnet).
- **MetaTrader 5 (MT5)** platform installed on your machine.
- Basic knowledge of **C#**, **MQL5**, and **socket communication**.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/MT5Bridge.git
   cd MT5Bridge
   ```

2. Restore the project dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

## Configuration

### MetaTrader 5 (MT5) Configuration

1. Open your MT5 platform.
2. Create an Expert Advisor (EA) and load the `SocketBridgeEA.mq5` file onto a chart in MT5.
3. The EA will connect to the C# server on port `5000` by default.

### C# Configuration

1. In the `MT5Bridge.DemoApp` project, ensure the server is configured to listen on the correct port (`5000`):
   ```csharp
   TcpListener listener = new TcpListener(IPAddress.Any, 5000);
   ```

2. You can modify the port in the `Program.cs` file if needed.

## Running the Project

To run the C# application (the server), navigate to the `MT5Bridge.DemoApp` directory and run the following command:

```bash
dotnet run --project MT5Bridge.DemoApp
```

This will start the server and it will listen for incoming connections from MT5.

## Testing

1. Ensure both the **MT5 terminal** and the **C# server application** are running.
2. In MT5, load the EA `SocketBridgeEA.mq5` onto a chart.
3. The EA should attempt to connect to the server, and you should see messages in the console log indicating successful connections, order executions, and market data retrieval.
4. Check the console output in the `MT5Bridge.DemoApp` to ensure the connection is successful.

## Contributing

We welcome contributions to this project! To get started, please fork the repository, make changes in a feature branch, and submit a pull request.

### Steps to contribute:
1. Fork the repository.
2. Create a new branch for your feature.
3. Make changes to the code.
4. Commit your changes and push the branch.
5. Submit a pull request to the main repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
```
