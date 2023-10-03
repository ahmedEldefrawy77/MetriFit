namespace MetriFit.Services.MealLogCaloriesServices
{
    public interface IMealLogCaloriesMeausrments
    {
        Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumed(MealLog mealLog);
        Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumedPercentage(MealLog mealLog);
    }
}
