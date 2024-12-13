using IoT.Dashboard.SensorDataAPI.Measurements;

namespace IoT.Dashboard.SensorDataAPI.Hubs;

public class SensorHub : Hub
{
    public async Task SendSensorData(Msurements data)
    {
        await Clients.All.SendAsync("ReceiveSensorData", data);
    }
}
