using MetriFit;

namespace Health_and_Nutritio;

public interface IMealLogTypeFactory
{
    Task<CaloriesConsumedPerMeal> GetCaloriesPerMealLog(MealLog meallog);

}
