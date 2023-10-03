namespace MetriFit;

public class FemaleBodyMeasurment : IUserGenderFactory
{
    public UserCalculatedMeasurments BodyMeasurments(User user, double ActivityLevel)
    {
        
        UserCalculatedMeasurments userMeasurments = new UserCalculatedMeasurments();
        //Body Fat
        if (user.HipCircumference == null)
            throw new ArgumentNullException(nameof(user.HipCircumference));

        userMeasurments.BodyFat = 163.205 * Math.Log10(user.WaistCircumference + user.HipCircumference.Value - user.NeckCircumference) - 97.684 * Math.Log10(user.Height) + 78.387;
      
        userMeasurments.LeanerBodyMass = (1 - userMeasurments.BodyFat / 100) * user.Weight;
         
        //BMR / BMR after Activity Level
        
        userMeasurments.BasalMetabolicRate = 370 + (9.82 * userMeasurments.LeanerBodyMass * 2.204);

        userMeasurments.BMRAfterActivityLevel = userMeasurments.BasalMetabolicRate * ActivityLevel;

        return userMeasurments;
    }
}
