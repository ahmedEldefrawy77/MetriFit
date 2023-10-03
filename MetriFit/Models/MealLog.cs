namespace MetriFit;

public  class MealLog : BaseEntitySettings
{
    public string? MealLogType { get; set; }

    public double ProtienConsumed { get; set; }

    public double CarbonhydrateConsumed { get; set; }

    public double FatConsumed { get; set; }

    public double Sugar { get; set; }

    public double RepastGrams { get; set; }

    public DateTime Date { get; set; }

    public Guid UserId { get; set; }

    public  CaloriesConsumedPerMeal? CaloriesConsumedPerMeal { get; set; }
    public Guid CaloriesConsumedPerMealId { get; set; }
    public  User? User { get; set; }
}