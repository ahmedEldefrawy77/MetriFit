
namespace MetriFit;
public class RefreshTokenRepository : BaseRepository<RefreshToken> , IRefreshTokenRepository    
{
    public RefreshTokenRepository(ApplicationDbContext context) : base (context)
    {

    }

    public async Task<RefreshToken?> GetRefreshTokenByUserId(Guid id)
    {
       RefreshToken? refresh = await Task.Run(() =>  _dbSet.FirstOrDefaultAsync(x=>x.UserId == id));
        return refresh;
    }
}

