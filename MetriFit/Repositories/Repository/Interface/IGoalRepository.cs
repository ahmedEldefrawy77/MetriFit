namespace MetriFit;
    public interface IGoalRepository : IBaseRepository<Goal>
    {
    Task DeleteGoalWithUserId(Guid id);

    }

