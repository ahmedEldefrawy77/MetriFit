namespace MetriFit;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Get(Guid id);
    Task<IEnumerable<T>> GetAll();

    Task<T> Update(T Entity);
    Task Delete(Guid id);
    Task DeleteAll();
    Task Delete(T Entity);

    Task Add(T Entity);
    Task<IDbContextTransaction> GetTransactoin();

}
