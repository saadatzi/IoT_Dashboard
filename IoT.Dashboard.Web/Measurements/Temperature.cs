namespace IoT.Dashboard.Web.Measurements
{
    public class Temperature
    {
        public string? Location { get; set; }
        public double? Value { get; set; }
        public DateTime Time { get; set; }
    }
}