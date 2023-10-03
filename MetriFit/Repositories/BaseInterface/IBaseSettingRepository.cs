namespace MetriFit;
    public interface IBaseSettingRepository<T> : IBaseRepository<T> where T : BaseEntitySettings
    {
    Task<IEnumerable<T>> Search(string name);
    }

