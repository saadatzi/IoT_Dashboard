namespace IoT.Dashboard.Web.Measurements;

public class Measurements
{
    public Temperature? Temperature { get; set; } = new Temperature();
    public Pressure? Pressure { get; set; } = new Pressure();
    public Humidity? Humidity { get; set; } = new Humidity();
}