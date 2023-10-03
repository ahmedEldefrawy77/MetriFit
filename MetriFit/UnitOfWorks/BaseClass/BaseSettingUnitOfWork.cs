namespace MetriFit;
    public class BaseSettingUnitOfWork<T> : BaseUnitOfWork<T> , IBaseSettingUnitOfWork<T> where T : BaseEntitySettings 
    {
        private readonly IBaseSettingRepository<T> _repository;

        public BaseSettingUnitOfWork(IBaseSettingRepository<T> repository) :base ( repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> SearchByName(string name) 
            => await _repository.Search(name);
       
    }
