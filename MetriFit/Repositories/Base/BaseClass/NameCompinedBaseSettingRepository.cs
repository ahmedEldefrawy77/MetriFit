namespace MetriFit;
    public class NameCompinedBaseSettingRepository<T> : BaseRepository<T>, INameCompinedBaseSettingRepository<T> where T : BaseEntitySettingNameCompind
    {
       
        public NameCompinedBaseSettingRepository(ApplicationDbContext context): base (context){ }

        public async Task<IEnumerable<T>> SearchByFirstName(string name) 
            => await Task.Run(() => _dbSet.Where(e => e.FirstName!.Contains(name)));
        public async Task<IEnumerable<T>> SearchByLastName(string name) 
            => await Task.Run(() => _dbSet.Where(e => e.LastName!.Contains(name)));

       
    
}

