namespace MetriFit;

public record MeasurmentsUpdate
{
    public string? Name { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double NeckCircumference { get; set; }
    public double WaistCircumference { get; set; }
    public double? HipCircumference { get; set; }
}
