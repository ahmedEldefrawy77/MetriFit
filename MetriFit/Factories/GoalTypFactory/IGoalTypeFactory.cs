namespace MetriFit;

public interface IGoalTypeFactory
{
    Goal GetGoalType(string goal,UserCalculatedMeasurments CalculatedMeasurments);
}
