namespace MetriFit;

public interface IAuthUserUnitOfWork : INameCompinedSettingUnitOfWork<User>
{
    Task<Token> Register(User record);
    Task<Token> Login(UserLoginRecord? loginRecord);
    Task Update(UserRequest? user, Guid id);
    Task<Token> UpdatePassword(PasswordRecord? Password,Guid id);
    Task<User?> GetByMail(string? email);
    Task Logout(string refreshToken);
    Task<User?> GetByToken(string refreshToken);
    Task<Token> Refresh(string refreshToken);
    Task<User> GetUserById(Guid id);

}
