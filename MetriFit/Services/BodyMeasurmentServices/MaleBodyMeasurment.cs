namespace MetriFit;          

public class MaleBodyMeasurment : IUserGenderFactory
{
    public  UserCalculatedMeasurments BodyMeasurments(User user, double ActivityLevel)
    {

        UserCalculatedMeasurments userMeasurments = new UserCalculatedMeasurments();
        //BodyFat
        userMeasurments.BodyFat =  86.010 * Math.Log10(user.WaistCircumference - user.NeckCircumference) - 70.041 * Math.Log10(user.Height) + 36.76;

        userMeasurments.LeanerBodyMass = (1 - userMeasurments.BodyFat / 100) * user.Weight;

        //BMR / BMR After Activity Level

        userMeasurments.BasalMetabolicRate = 370 + (9.82 * userMeasurments.LeanerBodyMass * 2.204);

        userMeasurments.BMRAfterActivityLevel = userMeasurments.BasalMetabolicRate * ActivityLevel;

        return userMeasurments;
    }
   
}
