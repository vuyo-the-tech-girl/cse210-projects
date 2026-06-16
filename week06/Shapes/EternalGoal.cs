using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    : base(name, description, points) { }
    
    public override int RecordEvent()
    {
        return GetPoints();
    }
    
    public override bool IsComplete() => false;
    
    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({base.GetType().Name}) - {GetPoints()} pts each time";
    }
    
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetName()},{_description},{GetPoints()}";
    }
}