using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points)
    : base(name, description, points)
    {
        _isComplete = false;
    }
    
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        return 0;
    }
    
    public override bool IsComplete() => _isComplete;
    
    public override string GetDetailsString()
    {
        string status = _isComplete? "[X]" : "[ ]";
        return $"{status} {GetName()} ({base.GetType().Name}) - {GetPoints()} pts";
    }
    
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{_description},{GetPoints()},{_isComplete}";
    }
}