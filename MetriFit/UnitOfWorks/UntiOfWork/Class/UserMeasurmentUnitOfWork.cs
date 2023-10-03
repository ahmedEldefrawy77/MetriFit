namespace MetriFit;

public class UserMeasurmentUnitOfWork : AuthUserUnitOfWork, IUserMeasurmentUnitOfWork 
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly RefreshTokenValidator _refreshTokenValidator;
    private readonly AccessOptions _accessOptions;
    private readonly RefreshOptions _refreshOptions;
    private readonly IRefreshTokenRepository _refreshRepository;
    private readonly IActivityLevel _activityLevel;
    private readonly IMealLogRepository _mealLogRepository;
 
    public UserMeasurmentUnitOfWork(IUserRepository userRepository,
                          IJwtProvider jwtProvider,
                          RefreshTokenValidator refreshValidator,
                          IOptions<AccessOptions> accessOptions,
                          IOptions<RefreshOptions> refreshOption,
                          IRefreshTokenRepository refreshRepository,
                          IActivityLevel activityLevel,
                          IMealLogRepository mealLogRepository
                          
                        )
                          : base(userRepository,
                                jwtProvider,
                                refreshValidator,
                                accessOptions,
                                refreshOption, 
                                refreshRepository)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _refreshTokenValidator = refreshValidator;
        _accessOptions = accessOptions.Value;
        _refreshOptions = refreshOption.Value;
        _refreshRepository = refreshRepository;
        _activityLevel = activityLevel;
        _mealLogRepository = mealLogRepository;
 
       
    }

    public async Task<UserCalculatedMeasurments> GetUserMeasurments(Guid id)
    {
        User? userFromDb = await _userRepository.GetUserById(id);
        if (userFromDb == null)
            throw new ArgumentNullException($"{nameof(userFromDb)}Invalid token");

        DateTime currentDate = DateTime.UtcNow;
        TimeSpan timeSinceLastMeasurmentsEntry = currentDate - userFromDb.LastMeasurmentsEntryDate;

        if (timeSinceLastMeasurmentsEntry.TotalDays > 14)
            throw new ArgumentException("its been 14 Days Since Last Data entry");


        UserCalculatedMeasurments calcM = _activityLevel.GetMeasurments(userFromDb);
        userFromDb.BasalMetabolicRate = calcM.BasalMetabolicRate;
        userFromDb.BmrafterActivityLevel = calcM.BMRAfterActivityLevel;
        userFromDb.BodyFat = calcM.BodyFat;
        userFromDb.LeanerBodyMass = calcM.LeanerBodyMass;
        await base.Update(userFromDb);

        return calcM;
    }

    public async Task<User> UpdateMeasurmentsData(UserMeasurmentsUpdate update, Guid id)
    {
        User? userFromDb = await _userRepository.GetUserById(id);
        if (userFromDb == null)
            throw new ArgumentNullException("invalid token");

        if (userFromDb.Gender == "Male")
        {
            userFromDb.Height = update.Height;
            userFromDb.Weight = update.Weight;
            userFromDb.NeckCircumference = update.NeckCircumference;
            userFromDb.WaistCircumference = update.WaistCircumference;
            userFromDb.LastMeasurmentsEntryDate = DateTime.UtcNow;
            await base.Update(userFromDb);
            return userFromDb;
        }
        else
        {
            if (userFromDb.HipCircumference == null)
                throw new ArgumentNullException("Hip Circumference cannot be null");

            userFromDb.HipCircumference = update.HipCircumference;
            userFromDb.Height = update.Height;
            userFromDb.Weight = update.Weight;
            userFromDb.NeckCircumference = update.NeckCircumference;
            userFromDb.WaistCircumference = update.WaistCircumference;
            userFromDb.LastMeasurmentsEntryDate = DateTime.UtcNow;
            await base.Update(userFromDb);
            return userFromDb;
        }
    }
  
}
