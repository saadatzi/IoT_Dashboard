# IoT Dashboard Project

## Description

This project is designed to collect sensor data (temperature, pressure, humidity), persist it in a time series database (InfluxDB), and display real-time updates on a Blazor dashboard.

![Aspire_SignalR](https://github.com/user-attachments/assets/c16c338e-dd46-451d-ac40-e95195dc0b1c)


## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Usage](#usage)
- [Technologies Used](#technologies-used)
- [Future Enhancements](#future-enhancements)
- [Contribution](#contribution)
- [License](#license)
- [Contact](#contact)

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/IoT_Dashboard.git
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

## Technologies Used

- **.NET 9**: For building the backend services and Blazor dashboard.
- **InfluxDB**: Time series database for storing sensor data.
- **Blazor**: For building the real-time dashboard.
- **SignalR**: For real-time communication between the server and clients.

## Future Enhancements

This project has a solid foundation, but there are several features and technologies that can be integrated or explored to enhance its capabilities and performance. Below are some suggestions:

### **1. Integration of MQTT Protocol**
- **Description**: MQTT (Message Queuing Telemetry Transport) is a lightweight messaging protocol ideal for IoT applications. It can be used to improve communication between sensors and the backend service.
- **How to Implement**:
  - Use an MQTT broker like [Eclipse Mosquitto](https://mosquitto.org/) or [HiveMQ](https://www.hivemq.com/).
  - Integrate an MQTT client library such as [MQTTnet](https://github.com/dotnet/MQTTnet) in the background service to subscribe to sensor data topics.
  - Replace or complement the existing data collection mechanism with MQTT for real-time, efficient communication.

### **2. Node-RED for Workflow Automation**
- **Description**: Node-RED is a flow-based development tool for IoT. It can be used to visually design and manage workflows between sensors, the backend, and external APIs.
- **How to Implement**:
  - Install Node-RED and set up a flow to process sensor data.
  - Use Node-RED to preprocess data before sending it to InfluxDB or other databases.
  - Integrate Node-RED with the existing SignalR or Blazor dashboard to push real-time updates.

### **3. gRPC for High-Performance Communication**
- **Description**: gRPC (Google Remote Procedure Call) is a high-performance, open-source framework for building distributed systems. It can be utilized to improve the efficiency of communication between the backend services.
- **How to Implement**:
  - Replace or complement REST APIs with gRPC for faster and more efficient communication.
  - Use gRPC streaming for real-time data updates from the backend to the front end.
  - Explore libraries like [gRPC for .NET](https://grpc.io/docs/languages/csharp/) to implement this.

### **4. Support for Additional Time Series Databases**
- **Description**: While InfluxDB is currently used, the project can be extended to support other time series databases like TimescaleDB, Prometheus, or OpenTSDB for flexibility.
- **How to Implement**:
  - Abstract the database layer to support multiple database types.
  - Implement a configuration option to switch between databases depending on the use case.

### **5. Data Analytics and Machine Learning**
- **Description**: Add a layer of analytics for predictive maintenance or anomaly detection using the collected sensor data.
- **How to Implement**:
  - Integrate libraries like ML.NET or TensorFlow.NET for machine learning models.
  - Build a feature to analyze historical data from InfluxDB and display insights on the dashboard.
  - Use real-time data streams for anomaly detection using tools like Apache Kafka.

### **6. Enhanced Front-End Features**
- **Description**: Add more interactivity and features to the Blazor dashboard.
- **How to Implement**:
  - Implement graphing libraries like [Plotly](https://plotly.com/) or [Chart.js](https://www.chartjs.org/) for advanced visualizations.
  - Allow users to set and save custom alerts for sensor thresholds.
  - Add a historical data view with date-range filters.

### **7. Support for Edge Computing**
- **Description**: Deploy parts of the system (e.g., data collection) on edge devices to reduce latency and bandwidth usage.
- **How to Implement**:
  - Create a lightweight version of the background service to run on edge devices like Raspberry Pi.
  - Use containerization (e.g., Docker) to make deployment easier on edge devices.

### **8. Security Enhancements**
- **Description**: Improve the security of the system to ensure safe communication and data storage.
- **How to Implement**:
  - Add TLS encryption for SignalR, REST API, and gRPC communication.
  - Implement OAuth or API key-based authentication for the InfluxDB API and front-end dashboard.
  - Regularly audit and update dependencies to address vulnerabilities.

### **9. Integration with Cloud Services**
- **Description**: Leverage cloud platforms for scalability and advanced features.
- **How to Implement**:
  - Use AWS IoT Core, Azure IoT Hub, or Google Cloud IoT for data ingestion and device management.
  - Store data in cloud-native databases like Amazon Timestream or Azure Time Series Insights.
  - Integrate with cloud-based visualization tools like Power BI for advanced reporting.

### **10. Cross-Platform Mobile Support**
- **Description**: Build a mobile app to monitor the IoT dashboard on the go.
- **How to Implement**:
  - Use Blazor Hybrid or .NET MAUI for cross-platform mobile development.
  - Provide push notifications for critical alerts or updates.

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
