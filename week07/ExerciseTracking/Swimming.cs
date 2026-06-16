using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_METERS = 50;
    
    public Swimming(DateTime date, int minutes, int laps)
    : base(date, minutes)
    {
        _laps = laps;
    }
    
    public override double GetDistance()
    {
        return (_laps * LAP_LENGTH_METERS) / 1000;
    }
    
    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }
    
    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}