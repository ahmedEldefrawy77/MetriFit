using MetriFit.UnitOfWorks.UntiOfWork.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MetriFit.UnitOfWorks.UntiOfWork.Class
{
    public class ExerciseUnitOfWork : BaseSettingUnitOfWork<Exercise>, IExerciseUnitOfWork
    {
        private readonly IExerciseRepository _exerciseRepository;

        private readonly IUserRepository _userRepository;

        public ExerciseUnitOfWork(IExerciseRepository exerciseRepository, IUserRepository userRepository) : base(exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            _userRepository = userRepository;
        }

        public async  Task<Exercise> CreatExercise(Exercise exercise, Guid id)
        {
            
            if(exercise  == null)
                throw new ArgumentNullException(nameof(exercise));

            if (exercise.CaloriesBurned == null)
                throw new ArgumentNullException(nameof(exercise.CaloriesBurned));
            User? userFromDb = await _userRepository.GetUserById(id);
            if (userFromDb == null)
                throw new ArgumentException("Invalid Token");

           exercise.UserId = userFromDb.Id;
           
            await _exerciseRepository.Add(exercise);
            return exercise;
        }

        public async Task DeleteExercise(Exercise ex) => await _exerciseRepository.Delete(ex.Id);


        public async  Task<List<Exercise>?> GetAllExercises(Guid id)
        {
          
            List<Exercise>? exercises = await _exerciseRepository.GetExercisesByUserId(id);

            if (exercises == null)
                throw new ArgumentNullException("there is no Exercises assostiated with this User");

            return exercises;
 
        }

        public async Task<List<Exercise>?> GetExercisesWithDate(DateTime? date, Guid id)
        {
            if(date == null)
                throw new ArgumentNullException(nameof(date));

            List<Exercise>? exercises = await _exerciseRepository.GetExerciseByDate(date, id);
            return exercises;

        }
       
    }
}
