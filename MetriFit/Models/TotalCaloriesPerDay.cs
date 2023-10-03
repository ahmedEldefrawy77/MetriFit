using System.Text.Json.Serialization;

namespace MetriFit;

public class TotalCaloriesPerDay : BaseEntity
{
    public double? TotalCalories { get; set; }
    public DateTime Date { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    public Guid UserId { get; set; }
}
