namespace MetriFit;

public  class RefreshToken : BaseEntity
{
    public string? Value { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiredAt { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }
}