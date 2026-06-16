using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    
    protected DateTime GetDate() => _date;
    protected int GetMinutes() => _minutes;
    
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    
    public virtual string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        return $"{dateStr} {GetType().Name} ({_minutes} min) - Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}