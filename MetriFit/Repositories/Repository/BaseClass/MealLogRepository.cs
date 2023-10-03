using Microsoft.EntityFrameworkCore;

namespace MetriFit;
public class MealLogRepository : BaseSettingRepository<MealLog>, IMealLogRepository
{
  
    public MealLogRepository(ApplicationDbContext Context) : base(Context){}

    public async Task<List<MealLog>?> GetMealLogById(Guid id)
   {

        List<MealLog> MealLogs = await _dbSet.Include(e=>e.CaloriesConsumedPerMeal).Where(e => e.UserId == id).ToListAsync();
        
        if(MealLogs == null)
            throw new ArgumentNullException(nameof(MealLogs));

        return MealLogs;
   }
    public async Task<List<MealLog>?> GetMealLogbyDate(DateTime date, Guid id)
    {
           List<MealLog>? MealLog = await GetMealLogById(id);
           List<MealLog>? MealLogByDate = await Task.Run(() => MealLog?.Where(e => e?.Date == date).ToList());

           return MealLogByDate;
    }

        

   public async Task<double?> GetAllMealCaloriesWithDate(DateTime date, Guid id)
   {
      List<MealLog> AllMealsPerDate = new List<MealLog>();
      AllMealsPerDate = await Task.Run(() => _dbSet.Include(e=>e.CaloriesConsumedPerMeal).Where(e => e.Date == date).ToListAsync());
      double? sum = 0;
      foreach (MealLog meal in AllMealsPerDate)
      {
        sum += meal.CaloriesConsumedPerMeal?.TotalCaloriesConsumed;

      }
     return sum;
   }
}

