namespace IoT.Dashboard.AppHost;

public class DataCollectionService(
    ILogger<DataCollectionService> logger,
    IInfluxDBClient influxDBClient,
    IOptions<InfluxDbSettings> influxDbSettings) : BackgroundService()
{
    private readonly ILogger<DataCollectionService> logger = logger;
    private readonly IInfluxDBClient influxDBClient = influxDBClient;
    private readonly IOptions<InfluxDbSettings> influxDbSettings = influxDbSettings;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            // Collect the data from sensors
            double temperature = GetTemperature();
            double pressure = GetPressure();
            double moisture = GetMoisture();

            // Persist data into InfluxDB
            await PersistDataToInfluxDB(temperature, pressure, moisture);

            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task PersistDataToInfluxDB(double temperatureValue, double pressureValue, double moistureValue)
    {
        var writeApiAsync = influxDBClient.GetWriteApiAsync();
        var temperature = new Temperature
        {
            Location = "floor",
            Value = temperatureValue,
            Time = DateTime.UtcNow
        };

        var pressure = new Pressure
        {
            Location = "floor",
            Value = pressureValue,
            Time = DateTime.UtcNow
        };

        var moisture = new Humidity
        {
            Location = "floor",
            Value = moistureValue,
            Time = DateTime.UtcNow
        };

        try
        {
            await writeApiAsync.WriteMeasurementAsync(temperature, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
            await writeApiAsync.WriteMeasurementAsync(pressure, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
            await writeApiAsync.WriteMeasurementAsync(moisture, WritePrecision.Ns, influxDbSettings.Value.Bucket, influxDbSettings.Value.Organization);
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
