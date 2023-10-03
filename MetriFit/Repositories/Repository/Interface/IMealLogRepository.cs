namespace MetriFit;
public interface IMealLogRepository : IBaseSettingRepository<MealLog>
    {
    Task<List<MealLog>?> GetMealLogbyDate(DateTime date, Guid id);
    Task<List<MealLog>?> GetMealLogById(Guid id);
    Task<double?> GetAllMealCaloriesWithDate(DateTime date, Guid id);
    }

