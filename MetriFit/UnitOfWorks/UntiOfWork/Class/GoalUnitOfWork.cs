using MetriFit.UnitOfWorks.UntiOfWork.Interface;

namespace MetriFit.UnitOfWorks.UntiOfWork.Class
{
    public class GoalUnitOfWork : BaseUnitOfWork<Goal>, IGoalUnitOfWork
    {
        private readonly IGoalRepository _GoalRepository;
        private readonly IGoalTypeFactory _GoalTypeFactory;
        private readonly IUserRepository _userRepository;
        private readonly IUserMeasurmentUnitOfWork _userMeasurmentUnitOfWork;
        public GoalUnitOfWork(IGoalRepository goalRepository,
            IUserRepository userRepository,
            IGoalTypeFactory goalTypeFactory,
            IAuthUserUnitOfWork authUserUnitOfWork,
            IActivityLevel activityLevel,
            IUserMeasurmentUnitOfWork userMeasurmentUnitOfWork) : base(goalRepository)
        {
            _GoalRepository = goalRepository;
            _userRepository = userRepository;
            _GoalTypeFactory = goalTypeFactory;
            _userMeasurmentUnitOfWork = userMeasurmentUnitOfWork;
        }

        public async Task<Goal> SetGoal(string goalType, Guid id)
        {
            User? userFromDb = await _userRepository.GetUserByIdWithGl(id);
            if(userFromDb == null ) 
                throw new ArgumentNullException(nameof(userFromDb));

            if (goalType == string.Empty)
               throw new ArgumentException("Goal has not been specified");

            if (userFromDb.Goal != null)
                throw new ArgumentException("you Have aleady a Goal if you want to set one: please remove the old Goal");
          
              UserCalculatedMeasurments userCalculatedM = await _userMeasurmentUnitOfWork.GetUserMeasurments(id);
            

            IGoalTypeFactory GoalType = GoalTypeFactory.GetGoalType(goalType, userCalculatedM);


            Goal UserGoal = GoalType.GetGoalType(goalType, userCalculatedM);
            
        
           UserGoal.UserId = id;

            await _GoalRepository.Add(UserGoal);

            return UserGoal;  
        }

        public async Task DeleteGoal(Guid id)
        {
            User? userFromDb = await _userRepository.GetUserByIdWithGl(id);
            if (userFromDb == null)
                throw new ArgumentNullException(nameof(userFromDb));

            if (userFromDb.Goal == null)
                throw new ArgumentNullException("There is no Goal has been set for this user");

            await _GoalRepository.Delete(userFromDb.Goal.Id);
        }
    }
}
