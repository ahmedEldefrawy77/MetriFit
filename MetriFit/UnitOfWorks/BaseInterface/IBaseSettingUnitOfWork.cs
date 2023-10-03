namespace MetriFit;

    public interface IBaseSettingUnitOfWork<T> : IBaseUnitOfWorks<T> where T: BaseEntitySettings
    {
        Task<IEnumerable<T>> SearchByName(string name);

    }

