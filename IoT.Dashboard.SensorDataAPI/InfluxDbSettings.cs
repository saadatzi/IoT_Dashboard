using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT.Dashboard.SensorDataAPI;

public class InfluxDbSettings
{
    public string? Url { get; set; }
    public string? Token { get; set; }
    public string? Organization { get; set; }
    public string? Bucket { get; set; }
}