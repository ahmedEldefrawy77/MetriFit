namespace MetriFit;
public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
{
    Task<RefreshToken?> GetRefreshTokenByUserId(Guid id);
}
