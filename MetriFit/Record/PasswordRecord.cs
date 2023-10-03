namespace MetriFit;

public record PasswordRecord
{
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }

}
