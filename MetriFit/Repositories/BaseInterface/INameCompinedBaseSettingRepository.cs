namespace MetriFit;
    public interface INameCompinedBaseSettingRepository<T> : IBaseRepository<T> where T : BaseEntitySettingNameCompind
    {
        Task<IEnumerable<T>> SearchByFirstName(string name);
        Task<IEnumerable<T>> SearchByLastName(string name);
       
    }
