using System.Text.Json.Serialization;

namespace MetriFit;

public  class Goal : BaseEntity
{

    public string? GoalType { get; set; }

    public double? CaloriesPerDayToBeEaten { get; set; }

    public DateTime DateStartedAt { get; set; }

    public DateTime DateExAt { get; set; }

    public Guid? UserId { get; set; }
    [JsonIgnore]
    public  User? User { get; set; }
}