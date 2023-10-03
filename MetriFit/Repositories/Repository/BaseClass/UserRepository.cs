namespace MetriFit;

public class UserRepository : NameCompinedBaseSettingRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context):base(context) { }
   
    public async Task<User?> GetUserById(Guid id)
        => await _dbSet.Include(t => t.RefreshToken).FirstOrDefaultAsync(e => e.Id == id);   
    public async Task<User?> GetbyToken(string token)
    => await _dbSet.Include(e=> e.RefreshToken).FirstOrDefaultAsync(e => e.RefreshToken.Value == token);

    public async Task<User?> GetUserByIdWithML(Guid id)
       => await _dbSet.Include(t => t.MealLog).FirstOrDefaultAsync(e => e.Id == id);

    public async Task<User?> GetUserByIdWithGl(Guid id)
        => await _dbSet.Include(t=>t.Goal).FirstOrDefaultAsync(e => e.Id == id);
    public async Task<IEnumerable<User>?> GetAllUsers()
    => await GetAll();

    public async Task<User?> SearchUserByMail(string? mail)
    {
        User? user = await Task.Run(() => _dbSet.Include(t=>t.RefreshToken).FirstOrDefaultAsync(e => e.Email == mail));
        return user;
    }

    public async Task<bool> IsEmailUniq(string email)
    {
        return !await _dbSet.AnyAsync(e => e.Email == email);

    }
}



