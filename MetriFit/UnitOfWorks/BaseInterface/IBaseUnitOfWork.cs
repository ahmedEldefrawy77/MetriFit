namespace MetriFit;

public interface IBaseUnitOfWorks<T> where T : class
{
    Task Creat(T unit);
    Task<T> Read(Guid id);
    Task Delete(Guid id);
    Task Delete(T unit);
    Task Update(T unit);
}
