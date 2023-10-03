namespace MetriFit.Services.MealLogCaloriesServices
{
    public class MealLogCaloriesMeasurments : IMealLogCaloriesMeausrments
    {
       
        public async Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumed(MealLog mealLog)
        {
            if (mealLog == null)
                throw new ArgumentNullException(nameof(mealLog));

            CaloriesConsumedPerMeal cal = new CaloriesConsumedPerMeal();
            cal.FatCalories = await Task.Run(() => mealLog.FatConsumed * 9);
            cal.CarbonhydrateCalories = await Task.Run(() => mealLog.CarbonhydrateConsumed * 4);
            cal.ProtienCalories = await Task.Run(() => mealLog.ProtienConsumed * 4);
            cal.SugarCalories = await Task.Run(() => mealLog.Sugar * 4);
            cal.TotalCaloriesConsumed = await Task.Run(() => cal.FatCalories + cal.CarbonhydrateCalories + cal.ProtienCalories + cal.SugarCalories);
            cal.Meal = mealLog;

            return cal;
        }

        public async Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumedPercentage(MealLog mealLog)
        {
            if (mealLog == null)
                throw new ArgumentNullException(nameof(mealLog));

            CaloriesConsumedPerMeal cal = new CaloriesConsumedPerMeal();
            cal.FatCalories = await Task.Run(() => (((mealLog.FatConsumed / 100 ) * mealLog.RepastGrams) * 9));
            cal.CarbonhydrateCalories = await Task.Run(() => (((mealLog.CarbonhydrateConsumed / 100) * mealLog.RepastGrams) * 4));
            cal.ProtienCalories = await Task.Run(() => (((mealLog.ProtienConsumed / 100) * mealLog.RepastGrams) * 4));
            cal.SugarCalories = await Task.Run(() => (((mealLog.Sugar / 100) * mealLog.RepastGrams) * 4));
            cal.TotalCaloriesConsumed = await Task.Run(() => cal.FatCalories + cal.CarbonhydrateCalories + cal.ProtienCalories + cal.SugarCalories);
            cal.Meal = mealLog;

            return cal;

        }

    }
}
