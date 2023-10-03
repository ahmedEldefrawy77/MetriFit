namespace MetriFit;
public class BaseSettingRepository<T> : BaseRepository<T>, IBaseSettingRepository<T> where T : BaseEntitySettings
{
   
    public BaseSettingRepository(ApplicationDbContext context) : base(context) { }
    public async Task<IEnumerable<T>> Search(string name)
        => await Task.Run(() => _dbSet.Where(e => e.Name!.Contains(name))); 
}
