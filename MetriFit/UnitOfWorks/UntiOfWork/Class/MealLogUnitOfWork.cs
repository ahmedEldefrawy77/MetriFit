using Health_and_Nutritio;


namespace MetriFit.UnitOfWorks.UntiOfWork.Class
{
    public class MealLogUnitOfWork : BaseSettingUnitOfWork<MealLog>, IMealLogUnitOfWork
    {
        private readonly IMealLogRepository _mealLogRepository;
        private readonly IMealLogTypeFactory _mealLogTypeFactory;
        private readonly IUserRepository _userRepository;
      
        public MealLogUnitOfWork(IMealLogRepository mealLogRepository,
            IMealLogTypeFactory mealLogTypeFactory,
            IUserRepository userRepository)
            : base(mealLogRepository)
        {
            _mealLogRepository = mealLogRepository;
            _mealLogTypeFactory = mealLogTypeFactory;
            _userRepository = userRepository;
        }

  
        public async Task<CaloriesConsumedPerMeal> CalculatTotalCaloriesConsumedPerMeal(MealLog mealLog,Guid id)
        {
            User? userFromDb = await _userRepository.GetUserByIdWithML(id);
            if (userFromDb == null)
                throw new ArgumentNullException(nameof(userFromDb));

            if(mealLog == null)
                throw new ArgumentNullException(nameof(mealLog));

           
            mealLog.UserId = id;

            CaloriesConsumedPerMeal cal = new CaloriesConsumedPerMeal();

            cal = await _mealLogTypeFactory.GetCaloriesPerMealLog(mealLog);
            
            mealLog.CaloriesConsumedPerMeal = cal;

            mealLog.CaloriesConsumedPerMealId = cal.Id;

            await base.Creat(mealLog);
            
            cal.MealId = mealLog.Id;

            await base.Update(mealLog);

            return cal;
        }
    }
}
