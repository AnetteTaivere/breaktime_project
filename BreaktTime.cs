using System;

public class BreakTime
{
    public TimeSpan StartTime { get; }
    public TimeSpan EndTime { get; }

    public BreakTime(TimeSpan startTime, TimeSpan endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}
