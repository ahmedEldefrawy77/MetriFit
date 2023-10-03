namespace MetriFit.Services.Goals
{
    public class LossWeightGoal : IGoalTypeFactory
    {
       
        public Goal GetGoalType(string goalType, UserCalculatedMeasurments CaclulatedMeasurments)
        {
            UserCalculatedMeasurments userCalc = new UserCalculatedMeasurments();
              
           Goal goal = new Goal();

                double? Deficit = CaclulatedMeasurments.BodyFat / 20 * 500;

                goal.CaloriesPerDayToBeEaten = CaclulatedMeasurments.BMRAfterActivityLevel - Deficit;
                goal.GoalType = goalType;
                goal.DateStartedAt = DateTime.UtcNow;
                goal.DateExAt = DateTime.UtcNow.AddDays(14);

                return goal;
          

        }
    }
}
