using MetriFit.Services.Goals;

namespace MetriFit;

public class GoalTypeFactory 
{

    
    public static IGoalTypeFactory GetGoalType(string goalType, UserCalculatedMeasurments user)
    {
        
        switch (goalType)
        {
            case "Loss Weight": return new LossWeightGoal();
               
            case "Gain Weight": return new GainWeightGoal();
               
        }
        throw new ArgumentException("Goal Type Cannot be uninsialized");            
    }
   
}


