namespace MetriFit;
public record AccessOptions
{
    public string? Issuser { get; set; }
    public string? Audience { get; set; }
    public string? SecretKey { get; set; }
    public int ExpireTimeInMintes { get; set; }
}
