namespace MetriFit.UnitOfWorks.UntiOfWork.Interface
{
    public interface IExerciseUnitOfWork : IBaseSettingUnitOfWork<Exercise>
    {
        Task<Exercise> CreatExercise(Exercise exercise,Guid id);
        Task<List<Exercise>?> GetAllExercises(Guid id);
        Task DeleteExercise(Exercise ex);
        Task<List<Exercise>?> GetExercisesWithDate(DateTime? date, Guid id);
    }
}
