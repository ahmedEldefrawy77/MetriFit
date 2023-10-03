namespace MetriFit;
public  class AuthUserUnitOfWork : NameCompinedBaseSettingUnitOfWork<User> , IAuthUserUnitOfWork
{
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly RefreshTokenValidator _refreshTokenValidator;
        private readonly AccessOptions _accessOptions;
        private readonly RefreshOptions _refreshOptions;
        private readonly IRefreshTokenRepository _refreshRepository;
    public AuthUserUnitOfWork(IUserRepository userRepository,
                          IJwtProvider jwtProvider,
                          RefreshTokenValidator refreshValidator,
                          IOptions<AccessOptions> accessOptions,
                          IOptions<RefreshOptions> refreshOption,
                          IRefreshTokenRepository refreshRepository) 
                          : base(userRepository) 
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _refreshTokenValidator = refreshValidator;
        _accessOptions = accessOptions.Value ;
        _refreshOptions = refreshOption.Value;
        _refreshRepository = refreshRepository;
    }
    #region Get 
    public async Task<User?> GetByMail(string? email)
    {
        if(email == null)
            throw new ArgumentNullException("email");

        User? userFromDb = await _userRepository.SearchUserByMail(email);
        if(userFromDb == null)
            throw new ArgumentNullException(nameof(email));

        return userFromDb;
    }
    public async Task<User> GetUserById(Guid id)
    {
        User? userFromDb = await _userRepository.GetUserById(id);
        if( userFromDb == null)
            throw new ArgumentNullException("Invalid Token");

        return userFromDb;
    }
    #endregion
    #region Token & RefreshToken 
    private RefreshToken GenerateRefreshToken(Guid Userid = default(Guid),
       Guid id = default(Guid))
    {
        string tokenValue = _jwtProvider.GetRefreshtoken();
        RefreshToken token = new()
        {
            CreatedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddMonths(_refreshOptions.ExpireTimeInMonths),
            Id = id,
            UserId = Userid,
            Value = tokenValue
        };
        return token;
    }
    private Token GenerateToken (User user, RefreshToken refreshToken)
    {
        Token token = new()
        {
            AccessToken = _jwtProvider.GetAccessToken(user),
            AccessTokneExDate = DateTime.UtcNow.AddMinutes(_accessOptions.ExpireTimeInMintes),
            RefreshToken = refreshToken.Value,
            RefreshTokenExDate = DateTime.UtcNow.AddMonths(_refreshOptions.ExpireTimeInMonths),
            role = user.Role = "User"
        };
        return token;
    }
    public async Task<User?> GetByToken(string refreshToken)
    {
        User? userFromDb = await _userRepository.GetbyToken(refreshToken);

        return userFromDb;
    }
    public async Task<Token> Refresh(string refreshToken)
    {
        
        User? UserFromDb = await _userRepository.GetbyToken(refreshToken);

        if (UserFromDb == null)
            throw new ArgumentNullException("Invalid token");

        if (UserFromDb == null || !_refreshTokenValidator.Validate(refreshToken) )
            throw new ArgumentException("Invalid Token");

        
        Token token = new()
        {
        
            AccessToken = _jwtProvider.GetAccessToken(UserFromDb),
            AccessTokneExDate = DateTime.UtcNow.AddMinutes(_accessOptions.ExpireTimeInMintes),
            RefreshToken = UserFromDb.RefreshToken?.Value,
            RefreshTokenExDate = UserFromDb.RefreshToken.ExpiredAt,
            role = UserFromDb.Role,
        };
        return token;
    }
    #endregion
    #region Login & Logout
    public async Task<Token> Login(UserLoginRecord? loginRecord)
    {
        if(loginRecord == null || loginRecord.Email == null)
            throw new ArgumentNullException(nameof(loginRecord));

      User? userFromDb = await _userRepository.SearchUserByMail(loginRecord.Email);
        if (userFromDb == null)
            throw new ArgumentNullException($"{nameof(userFromDb)}there is no User with this Email");

        if (!BCrypt.Net.BCrypt.Verify(loginRecord.Password, userFromDb.Password))
            throw new ArgumentException($"{nameof(loginRecord)} Password is not Correct.");

        

        if(userFromDb.RefreshToken == null )
        {
            userFromDb.RefreshToken = GenerateRefreshToken(userFromDb.Id);
            await base.Update(userFromDb);
        }
        
        if (!_refreshTokenValidator.Validate(userFromDb.RefreshToken.Value))
        {
            userFromDb.RefreshToken = GenerateRefreshToken(userFromDb.Id);
            await base.Update(userFromDb);
        }
        Token token = GenerateToken(userFromDb, userFromDb.RefreshToken);
        return token;
    }

    public async Task Logout(string refreshToken)
    {
        if (refreshToken == null || refreshToken == string.Empty)
            throw new ArgumentException("Invalid Token");

       User? userFromDb = await GetByToken(refreshToken);
        if (userFromDb == null ||!_refreshTokenValidator.Validate(refreshToken))
            throw new ArgumentException($"{nameof(userFromDb)} Invalid Token");

        if(userFromDb.RefreshToken != null)
        await _refreshRepository.Delete(userFromDb.RefreshToken.Id);
    }
   
    #endregion
    #region User Registration
    public async Task<Token> Register(User user)
    {
       user.RefreshToken = GenerateRefreshToken();

       user.CreatedAt = DateTime.UtcNow;

        user.LastMeasurmentsEntryDate = user.CreatedAt;

        await this.Creat(user);

        Token token = GenerateToken(user, user.RefreshToken);

        return token;
    }
    public override async Task Creat(User user)
    {
        if(user == null || user.Email==null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        User? userFromDb = await _userRepository.SearchUserByMail(user.Email);
        if (userFromDb != null)
            throw new ArgumentException(nameof(user), "is already Registerd");

        if (user.Password?.Length < 5)
            throw new ArgumentException(nameof(user.Password), "password must be at least more then 5");

        user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password);

        await base.Creat(user);
      
    }
    #endregion
    #region Update User & Update Password

    //supposed to be made by prototype Pattern
    public async Task Update(UserRequest? userRequest, Guid id)
    {
        User? userFromDb = await _userRepository.GetUserById(id);
        if (userFromDb == null)
            throw new ArgumentNullException(nameof(userRequest), "Invalid Token");

        if(userRequest ==  null)
            throw new ArgumentNullException(nameof(userRequest));
        
        User user = new();
        user.Id = id;
        user.FirstName = userRequest.FirstName;
        user.LastName = userRequest.LastName;
        user.Email = userRequest.Email;
        user.DateOfBirth = userFromDb.DateOfBirth;
        user.Goal = userFromDb.Goal;
        user.Weight = userFromDb.Weight;
        user.Height = userFromDb.Height;
        user.HipCircumference = userFromDb.HipCircumference;
        user.NeckCircumference = userFromDb.NeckCircumference;
        user.WaistCircumference = userFromDb.WaistCircumference;
        user.Gender = userFromDb.Gender;
        user.ProfilePicture = userRequest?.ProfilePicture;
        user.Role = userFromDb.Role;
        user.RefreshToken = userFromDb.RefreshToken;
        user.ActivityType = userFromDb.ActivityType;
        user.BodyFat = userFromDb.BodyFat;   
        user.CreatedAt = userFromDb.CreatedAt;
        user.Password = userFromDb.Password;
        user.BmrafterActivityLevel = userFromDb.BmrafterActivityLevel;
        

        await Update(user);
    }
    public async Task<Token> UpdatePassword(PasswordRecord? Password, Guid id)
    {
       User? userFromDb = await _userRepository.GetUserById(id);
        if(userFromDb ==null )
            throw new ArgumentNullException($"{nameof(userFromDb)} Invalid Token");

        if (!BCrypt.Net.BCrypt.Verify(Password?.OldPassword, userFromDb.Password))
            throw new ArgumentException(nameof(Password), "password is incorrect");

        if (Password?.NewPassword?.Length < 5)
            throw new ArgumentException("Password has to be at least 5");

        userFromDb.Password = BCrypt.Net.BCrypt.HashPassword(Password?.NewPassword);

        RefreshToken refreshToken = GenerateRefreshToken(id);
        Token token = GenerateToken(userFromDb, refreshToken);
        return token;
    }

   

    #endregion

}

