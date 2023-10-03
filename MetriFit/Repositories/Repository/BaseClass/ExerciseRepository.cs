using Microsoft.EntityFrameworkCore;

namespace MetriFit;

    public class ExerciseRepository : BaseSettingRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Exercise>> GetExercisesByUserId(Guid userId)
        {
          List<Exercise> Exercises = new List<Exercise>();
          Exercises = await _dbSet.Include(e=>e.User).Where(e=> e.UserId == userId).ToListAsync();
          return Exercises;
        }
              
        public async Task<List<Exercise>> GetExerciseByDate(DateTime? date, Guid id)
        {
        #region old Version
        //using (var UsersExercisesContext = new UsersExercisesDbContext())
        //{
        //    List<Exercise?> Exercises = await GetExercisesById(id);

        //    List<Exercise?> ExDate = Exercises.Where(e => e?.Date == date).ToList();
        //    return ExDate;

        //}
        #endregion
           
        List<Exercise> Exercises = new List<Exercise>();
        Exercises = await _dbSet
            .Where(e => e.UserId == id && e.DateCreatedAt == date)
            .ToListAsync();
        return Exercises;
        }

       
    }
