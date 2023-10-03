using Health_and_Nutritio;
using MetriFit.Services.MealLogCaloriesServices;

namespace MetriFit;

public class MealLogTypeFacotry :  IMealLogTypeFactory
{ 
    private readonly IMealLogCaloriesMeausrments _mealLogCaloriesMeasurments;
    public MealLogTypeFacotry(IMealLogCaloriesMeausrments mealLogCaloriesMeasurments)
    {
          _mealLogCaloriesMeasurments = mealLogCaloriesMeasurments;
    }
    public async Task<CaloriesConsumedPerMeal> GetCaloriesPerMealLog(MealLog meallog)
    {
        CaloriesConsumedPerMeal cal =  new CaloriesConsumedPerMeal();
       switch(meallog.MealLogType)
        {
            case "Raw Log": 
                
                cal = await ImplementingRowLog(meallog);
                 return cal;
            case "Percentage":
                
                cal = await ImplementingPercentage(meallog);
                return cal;
        }
        throw new ArgumentException("Meal Log Has been not correctily specified");
    }
    private async Task<CaloriesConsumedPerMeal> ImplementingRowLog(MealLog mealLog)
    {
        CaloriesConsumedPerMeal cal = new CaloriesConsumedPerMeal();
       
        cal = await _mealLogCaloriesMeasurments.CalculatTotalCaloriesConsumed(mealLog);
        return cal;
    }
    private async Task<CaloriesConsumedPerMeal> ImplementingPercentage(MealLog mealLog)
    {
        CaloriesConsumedPerMeal cal = new CaloriesConsumedPerMeal();
        cal = await _mealLogCaloriesMeasurments.CalculatTotalCaloriesConsumedPercentage(mealLog);
        return cal;
    }
}
