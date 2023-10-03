namespace MetriFit;

public interface IUserMeasurmentUnitOfWork : INameCompinedSettingUnitOfWork<User>
{
    Task<UserCalculatedMeasurments> GetUserMeasurments(Guid id);
    Task<User> UpdateMeasurmentsData(UserMeasurmentsUpdate update, Guid id);

}
