namespace MetriFit;

public record RefreshOptions
{
    public string? SecretKey { get; set; }
    public int ExpireTimeInMonths { get; set; }
}
