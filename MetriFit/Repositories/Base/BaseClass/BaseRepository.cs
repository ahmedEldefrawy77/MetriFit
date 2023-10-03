namespace MetriFit;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected DbSet<T> _dbSet;
    protected DbSet<IEnumerable<T>> _entitiesDbSet;
    private readonly ApplicationDbContext _context;

    public BaseRepository( ApplicationDbContext context)
    {
        _dbSet = context.Set<T>();
        _entitiesDbSet = context.Set<IEnumerable<T>>();
        _context = context;
    }
    #region Exception
    protected virtual void ThrowExceptionIfParameterNotSupplied(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException($"{entity} parameter not Supplied");
            
    }

    protected async virtual void ThrowExceptionIfEntityDoesnotExistInDb(T entity)
    {
        T? EntityFromDb = await Get(entity.Id);
        if (EntityFromDb == null)
            throw new ArgumentNullException($"{entity} doesnot exist in Db");
    }
    protected async virtual void ThrowExceptionIfEntityDoesnotExistInDb(Guid id)
    {
        T? EntityFromDb = await Get(id);
        if (EntityFromDb == null)
            throw new ArgumentNullException($"{id} doesnot exist in Db");
    }
    #endregion
    #region Add
    public async Task Add(T entity)
    {
        ThrowExceptionIfParameterNotSupplied(entity);
        
        await _dbSet.AddAsync(entity);
       await _context.SaveChangesAsync();
    }
    #endregion
    #region Delete
    public async Task Delete(Guid id)
    {
        ThrowExceptionIfEntityDoesnotExistInDb(id);

        T? EntityFromDb = await Get(id);
        await Task.Run(() => _dbSet.Remove(EntityFromDb));
        await _context.SaveChangesAsync();
    }
    public async Task Delete(T entity)
    {
        ThrowExceptionIfEntityDoesnotExistInDb(entity);

        await Task.Run(() => _dbSet.Remove(entity));
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAll()
    {
        IEnumerable<T> EntitiesFromDb = await _dbSet.ToListAsync();
        await Task.Run(()=> _entitiesDbSet.Remove(EntitiesFromDb));
        await _context.SaveChangesAsync();
    }
    #endregion
    #region Get
    public async Task<T> Get(Guid id)
    {
       T? EntityFromDb = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (EntityFromDb == null)
            throw new ArgumentNullException("There is no Entity in Db With this Id: BaseRepository");

        return EntityFromDb;
    }

    public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();
   

    #endregion
    #region Transaction
    public async Task<IDbContextTransaction> GetTransactoin()=> await _context.Database.BeginTransactionAsync();
    #endregion
    #region Update 
    public async Task<T> Update(T Entity)
    {
        ThrowExceptionIfEntityDoesnotExistInDb(Entity);

        await Task.Run(() => _context.Update(Entity));
        await _context.SaveChangesAsync();
        return Entity;
    }
    #endregion
    protected async Task SaveChangesAsync()=> await _context.SaveChangesAsync();
}
