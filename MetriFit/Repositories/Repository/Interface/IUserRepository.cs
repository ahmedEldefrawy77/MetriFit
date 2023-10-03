namespace MetriFit;
public interface IUserRepository : INameCompinedBaseSettingRepository<User>
{
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByIdWithML(Guid id);
    Task<User?> GetUserByIdWithGl(Guid id);
    Task<IEnumerable<User>?> GetAllUsers();
    Task<User?> SearchUserByMail(string mail);
    Task<User?> GetbyToken(string token);
    Task<bool> IsEmailUniq(string email);
}
