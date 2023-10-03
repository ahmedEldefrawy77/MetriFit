namespace MetriFit;

public class NameCompinedBaseSettingUnitOfWork<T> : BaseUnitOfWork<T> , INameCompinedSettingUnitOfWork<T> 
    where T : BaseEntitySettingNameCompind
{
    private readonly INameCompinedBaseSettingRepository<T> _repository;

    public NameCompinedBaseSettingUnitOfWork(INameCompinedBaseSettingRepository<T> repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T?>> SearchByName(string fName, string lName)
    {
       IEnumerable<T?> EntityFromDb =  await _repository.SearchByFirstName(fName);
        if(EntityFromDb == null)
        {
            IEnumerable<T?> lNameEnittyFromDb = await _repository.SearchByLastName(lName);
            if(lNameEnittyFromDb == null)
            {
                throw new ArgumentNullException($"there is no Entity in Db With this First Name {EntityFromDb} or Last Name {lNameEnittyFromDb} you have given");
            }
            return lNameEnittyFromDb;
        }
        return EntityFromDb;
    }
}
