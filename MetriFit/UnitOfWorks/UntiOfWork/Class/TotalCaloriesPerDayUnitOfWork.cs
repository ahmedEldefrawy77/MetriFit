using MetriFit.UnitOfWorks.UntiOfWork.Interface;

namespace MetriFit.UnitOfWorks.UntiOfWork.Class
{
    public class TotalCaloriesPerDayUnitOfWork : BaseUnitOfWork<TotalCaloriesPerDay> , ITotalCaloriesPerDayUnitOfWork
    {
        private readonly ITotalCaloriesPerDayRepository _totalCaloriesPerDayRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMealLogRepository _mealLogRepository;
        public TotalCaloriesPerDayUnitOfWork(ITotalCaloriesPerDayRepository totalCaloriesPerDayRepository,
            IUserRepository userRepository,
            IMealLogRepository mealLogRepository)
            : base(totalCaloriesPerDayRepository)
        {
            _totalCaloriesPerDayRepository = totalCaloriesPerDayRepository;
            _userRepository = userRepository;
            _mealLogRepository = mealLogRepository;
        }

        public async Task<TotalCaloriesPerDay?> GetTotalCaloriesPerDay(DateTime date, Guid id)
        {
            User? userFromDb = await _userRepository.GetUserByIdWithML(id);
            if (userFromDb == null)
                throw new ArgumentNullException("invalid Token");

            List<MealLog>? Meals = await _mealLogRepository.GetMealLogbyDate(date, id);

            double? TotalCaloriesForMeals = 0;
            if (Meals == null)
                throw new ArgumentNullException(nameof(Meals));

            foreach (MealLog meal in Meals)
            {
                TotalCaloriesForMeals += meal.CaloriesConsumedPerMeal?.TotalCaloriesConsumed;
            }
            TotalCaloriesPerDay UserTotalCalories = new TotalCaloriesPerDay();
            UserTotalCalories.TotalCalories = TotalCaloriesForMeals;
            UserTotalCalories.Date = date;
            UserTotalCalories.UserId = id;

            await base.Creat(UserTotalCalories);

            return UserTotalCalories;
        }
    }
}
