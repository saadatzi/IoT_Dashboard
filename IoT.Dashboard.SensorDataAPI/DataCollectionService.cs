using IoT.Dashboard.SensorDataAPI.Measurements;

namespace IoT.Dashboard.SensorDataAPI;

public class DataCollectionService(
    ILogger<DataCollectionService> logger,
    IInfluxDBClient influxDBClient,
    IOptions<InfluxDbSettings> influxDbSettings,
    IHubContext<SensorHub> hubContext
    ) : BackgroundService()
{
    private readonly ILogger<DataCollectionService> logger = logger;
    private readonly IInfluxDBClient influxDBClient = influxDBClient;
    private readonly IOptions<InfluxDbSettings> influxDbSettings = influxDbSettings;
    private readonly IHubContext<SensorHub>? hubContext = hubContext;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Collect the data from sensors
            double temperature = GetTemperature();
            double pressure = GetPressure();
            double moisture = GetMoisture();

            var measurements = CreateMeasuremens(temperature, pressure, moisture);

            // Persist data into InfluxDB
            await PersistDataToInfluxDB(measurements);

            await hubContext!.Clients.All.SendAsync("ReceiveSensorData", measurements, cancellationToken: stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }

    private static Msurements CreateMeasuremens(double temperatureValue, double pressureValue, double humidityValue)
    {
        var temperaturePoint = new Temperature
        {
            Location = "floor",
            Value = temperatureValue,
            Time = DateTime.UtcNow
        };

        var pressurePoint = new Pressure
        {
            Location = "floor",
            Value = pressureValue,
            Time = DateTime.UtcNow
        };

        var humidityPoint = new Humidity
        {
            Location = "floor",
            Value = humidityValue,
            Time = DateTime.UtcNow
        };

        return new Msurements { Temperature = temperaturePoint, Pressure = pressurePoint, Humidity = humidityPoint };
    }

    private async Task PersistDataToInfluxDB(Msurements measurements)
    {
        var writeApiAsync = influxDBClient.GetWriteApiAsync();

        try
        {
            await writeApiAsync.WriteMeasurementAsync(measurements.Temperature, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
            await writeApiAsync.WriteMeasurementAsync(measurements.Pressure, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
            await writeApiAsync.WriteMeasurementAsync(measurements.Humidity, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error writing to InfluxDB");
        }
    }

    private static double GetTemperature()
    {
        return 25 + new Random().NextDouble();
    }

    private static double GetPressure()
    {
        return 1013 + new Random().NextDouble();
    }

    private static double GetMoisture()
    {
        return 50 + new Random().NextDouble();
    }
}
