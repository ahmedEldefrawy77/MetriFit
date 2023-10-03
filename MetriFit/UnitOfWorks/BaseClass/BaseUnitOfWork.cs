namespace MetriFit;
public class BaseUnitOfWork<T> : IBaseUnitOfWorks<T> where T : BaseEntity
{
    private readonly IBaseRepository<T> _repository;
    public BaseUnitOfWork(IBaseRepository<T> repository) => _repository = repository;

    public virtual async Task<T> Read(Guid id) => await _repository.Get(id);
    public virtual async Task Creat(T  entity) => await _repository.Add(entity);
    public virtual async Task Delete(Guid id) => await _repository.Delete(id);
    public virtual async Task Delete(T entity) => await _repository.Delete(entity.Id);
    public virtual async Task Update(T entity) => await _repository.Update(entity);
   

}

