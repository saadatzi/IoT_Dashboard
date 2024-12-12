# IoT Dashboard Project

## Description

This project is designed to collect sensor data (temperature, pressure, moisture), persist it in a time series database (InfluxDB), and display real-time updates on a Blazor dashboard. Additionally, it includes a BI dashboard to show cumulative cost metrics.

## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Usage](#usage)
- [Technologies Used](#technologies-used)
- [Contribution](#contribution)
- [License](#license)
- [Contact](#contact)

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/iot-dashboard.git
   ```

2. **Install .NET SDK**

   Ensure you have the [.NET 9 SDK](https://dotnet.microsoft.com/download) installed on your machine.

3. **Restore NuGet Packages**

   Navigate to the project directory and restore the NuGet packages:

   ```bash
   dotnet restore
   ```

4. **Set Up InfluxDB**

   - **Using Docker:**

     ```bash
     docker run -d --name influxdb2 --publish 8086:8086 --mount type=volume,source=influxdb2-data,target=/var/lib/influxdb2 --mount type=volume,source=influxdb2-config,target=/etc/influxdb2 --env DOCKER_INFLUXDB_INIT_MODE=setup --env DOCKER_INFLUXDB_INIT_USERNAME=sss --env DOCKER_INFLUXDB_INIT_PASSWORD=AtLeast8CharP@ss --env DOCKER_INFLUXDB_INIT_ORG=SSS --env DOCKER_INFLUXDB_INIT_BUCKET=building influxdb:2
     ```

## Configuration

1. **Update `appsettings.json`**

   Ensure the `InfluxDb` section in `appsettings.json` is configured with your InfluxDB details:

   ```json
   {
     "InfluxDb": {
       "Url": "http://localhost:8086",
       "Token": "your-influxdb-token",
       "Organization": "sss",
       "Bucket": "building"
     }
   }
   ```

2. **Generate InfluxDB API Token**

   - Log in to the InfluxDB UI at `http://localhost:8086`.
   - Navigate to **Settings > API Tokens** and generate a new token with the necessary permissions.

## Running the Application

1. **Build the Solution**

   ```bash
   dotnet build
   ```

2. **Start the Background Service**

   - Navigate to the background service project directory.
   - Run the service:

     ```bash
     dotnet run
     ```

3. **Launch the Blazor Dashboard**

   - Navigate to the Blazor project directory.
   - Start the dashboard:

     ```bash
     dotnet run
     ```

## Usage

- **Data Collection**

  The background service collects sensor data at regular intervals and persists it to InfluxDB.

- **Real-Time Dashboard**

  The Blazor dashboard displays real-time sensor data using SignalR.

- **BI Dashboard**

  The BI dashboard shows cumulative cost metrics based on the sensor data.

## Technologies Used

- **.NET 9**: For building the backend services and Blazor dashboard.
- **InfluxDB**: Time series database for storing sensor data.
- **Blazor**: For building the real-time dashboard.
- **SignalR**: For real-time communication between the server and clients.

## Contribution

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes.
4. Push the branch to your forked repository.
5. Submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or issues, please contact [saadatzi@gmail.com](mailto:saadatzi@gmail.com).