namespace MetriFit;

public interface IUserGenderFactory
{
    //BodyFat percentage 
    UserCalculatedMeasurments BodyMeasurments(User user, double ActivityLevel);

}

