using System.Text.Json.Serialization;

namespace MetriFit;

public  class Exercise : BaseEntitySettings
{ 
    public double? CaloriesBurned { get; set; }

    public DateTime DateCreatedAt { get; set; }

    public Guid UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}