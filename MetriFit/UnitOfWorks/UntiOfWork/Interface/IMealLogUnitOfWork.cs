namespace MetriFit;

public interface IMealLogUnitOfWork : IBaseSettingUnitOfWork<MealLog>
{
    Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumedPerMeal(MealLog mealLog,Guid id);
    
}
