namespace MetriFit.UnitOfWorks.UntiOfWork.Interface
{
    public interface ITotalCaloriesPerDayUnitOfWork : IBaseUnitOfWorks<TotalCaloriesPerDay>
    {
        Task<TotalCaloriesPerDay?> GetTotalCaloriesPerDay(DateTime date, Guid id);
    }
}
