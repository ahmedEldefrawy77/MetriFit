namespace MetriFit;

public interface IExerciseRepository : IBaseSettingRepository<Exercise>
{
    Task<List<Exercise>> GetExerciseByDate(DateTime? date, Guid userId);
    Task<List<Exercise>> GetExercisesByUserId(Guid id);
}
