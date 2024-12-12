using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;

[Measurement("temperature")]
public class Temperature
{
    [Column("location", IsTag = true)] public string? Location { get; set; }
    [Column("value")] public double? Value { get; set; }
    [Column(IsTimestamp = true)] public DateTime Time { get; set; }
}

[Measurement("pressure")]
public class Pressure
{
    [Column("location", IsTag = true)] public string? Location { get; set; }
    [Column("value")] public double Value { get; set; }
    [Column(IsTimestamp = true)] public DateTime Time { get; set; }
}

[Measurement("humidity")]
public class Humidity
{
    [Column("location", IsTag = true)] public string? Location { get; set; }
    [Column("value")] public double Value { get; set; }
    [Column(IsTimestamp = true)] public DateTime Time { get; set; }
}