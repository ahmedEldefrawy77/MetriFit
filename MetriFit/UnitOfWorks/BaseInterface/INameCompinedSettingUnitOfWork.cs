namespace MetriFit;

    public interface INameCompinedSettingUnitOfWork<T> : IBaseUnitOfWorks<T> where T : BaseEntitySettingNameCompind
    {
        Task<IEnumerable<T?>> SearchByName(string fName, string lName);
       

    }

