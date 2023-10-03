using System.Security.Claims;

namespace MetriFit;

public class ActivityLevel : IActivityLevel
{
   
    public UserCalculatedMeasurments GetMeasurments(User user)
    {

        UserCalculatedMeasurments Calculated = new UserCalculatedMeasurments();

     
        switch(user.ActivityType) 
        {
            case "Sedentary": return ImplementigFactory(user,1.2);
            case "Lightly Active":  return ImplementigFactory(user, 1.357);
            case "Moderately Active": return ImplementigFactory(user, 1.55);
            case "Very Active": return ImplementigFactory(user, 1.725);
            case "Extremely Active": return ImplementigFactory(user, 1.9);
        }
        throw new ArgumentException("Activity Level has not been correctly Specified");
    }
    private UserCalculatedMeasurments ImplementigFactory(User user , double ActivityLevel)
    {
        IUserGenderFactory Measurments = UserGenderFactory.BodyMeasurments(user, ActivityLevel);
        UserCalculatedMeasurments calcM = Measurments.BodyMeasurments(user, ActivityLevel);
        return calcM;
    }
}
