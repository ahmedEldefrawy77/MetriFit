namespace MetriFit.Services.Goals
{
    public class GainWeightGoal : IGoalTypeFactory
    {
       

        public Goal GetGoalType(string goal, UserCalculatedMeasurments CaclulatedMeasurments)
        {
            

            Goal goal1 = new Goal();
            double Gain;
            if (CaclulatedMeasurments.BodyFat < 15)
            {
                Gain = 700;
            }
            else if (CaclulatedMeasurments.BodyFat > 15 && CaclulatedMeasurments.BodyFat < 20)
            {
                Gain = 500;
            }
            else
            {
                Gain = 200;
            }

            goal1.CaloriesPerDayToBeEaten = CaclulatedMeasurments.BMRAfterActivityLevel + Gain;
            goal1.GoalType = "Gain Weight";

            goal1.DateStartedAt = DateTime.UtcNow;
            goal1.DateExAt = DateTime.UtcNow.AddDays(14);

            return goal1;
        }
    }
}
