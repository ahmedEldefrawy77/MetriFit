namespace MetriFit.UnitOfWorks.UntiOfWork.Interface
{
    public interface IGoalUnitOfWork : IBaseUnitOfWorks<Goal>
    {
        Task<Goal> SetGoal(string goalType,Guid id);
        Task DeleteGoal(Guid id);
    }
}
