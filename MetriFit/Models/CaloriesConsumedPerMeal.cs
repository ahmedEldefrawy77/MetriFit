using System.Text.Json.Serialization;

namespace MetriFit;

public  class CaloriesConsumedPerMeal : BaseEntity
{

    public double? ProtienCalories { get; set; }

    public double? CarbonhydrateCalories { get; set; }

    public double? FatCalories { get; set; }

    public double? SugarCalories { get; set; }

    public double? TotalCaloriesConsumed { get; set; }

    public DateTime Date { get; set; }

    public Guid MealId { get; set; }
    [JsonIgnore]
    public MealLog? Meal { get; set; }
}