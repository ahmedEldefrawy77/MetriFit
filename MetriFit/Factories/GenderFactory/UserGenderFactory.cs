namespace MetriFit;
public class UserGenderFactory
{

    public static IUserGenderFactory BodyMeasurments(User user, double ActivityLevel)
    {
       switch(user.Gender)
       {
            case "Male": return new MaleBodyMeasurment();

            case "Female": return new FemaleBodyMeasurment();
       }
        throw new ArgumentException("Gender Has not been Specified");
    }
}


//private readonly IUserBodyMeasurmentFactory _userActivityFactory;

//public UserGenderFactory(IUserBodyMeasurmentFactory userActivityFactory)
//{
//    _userActivityFactory = userActivityFactory;
//}

//public async Task<UserCalculatedMeasurments> GetUserBodyMeasurments(User user)
//{
//    UserCalculatedMeasurments Measurments = new UserCalculatedMeasurments();

//    switch (user.Gender)
//    {
//        case "Male":
//            Measurments = await _userActivityFactory.GetMaleCalculatedMeasurmentBaseOfActivityLv(user);

//            return Measurments;

//        case "Femal":
//            Measurments = await _userActivityFactory.GetFemaleCalculatedMeasurmentBaseOfActivityLv(user);

//            return Measurments;
//    }
//    throw new ArgumentException("Gender has not been correctily specified");
//}