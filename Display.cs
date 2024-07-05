public class BreakTimeDisplay
{
    public void DisplayBusiestPeriod(List<BreakTime> breakTimes)
    {
        if (breakTimes.Count == 0)
        {
            Console.WriteLine("No breaktimes available.");
            return;
        }

        // List to store events (start and end times of breaks)
        List<(TimeSpan time, int type)> events = new List<(TimeSpan time, int type)>();
        foreach (var bt in breakTimes)
        {
            events.Add((bt.StartTime, 1));  // 1 for start
            events.Add((bt.EndTime, -1));   // -1 for end
        }

        events = events.OrderBy(e => e.time).ThenBy(e => e.type).ToList();

        // Variables to track the busiest period
        int currentDrivers = 0;
        int maxDrivers = 0;
        TimeSpan busiestStart = TimeSpan.Zero;
        TimeSpan busiestEnd = TimeSpan.Zero;
        TimeSpan lastTime = TimeSpan.Zero;

        foreach (var e in events)
        {
            if (currentDrivers > maxDrivers)
            {
                maxDrivers = currentDrivers;
                busiestStart = lastTime;
                busiestEnd = e.time;
            }

            currentDrivers += e.type;
            lastTime = e.time;
        }
        Console.WriteLine($"Busiest period: {busiestStart:hh\\:mm}-{busiestEnd:hh\\:mm} with {maxDrivers} drivers on break.");
    }
}
