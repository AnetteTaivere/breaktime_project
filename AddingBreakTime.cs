using System.Globalization;

public class BreakTimeManager
{
    private List<BreakTime> breakTimes = new List<BreakTime>(); // Private field for storing break times

    public List<BreakTime> BreakTimes => breakTimes; // Public property to access breakTimes

    public void AddBreakTime(string input)
    {
        try
        {
            if (input.Length != 10 || input[2] != ':' || input[7] != ':')
            {
                throw new FormatException("Input should be in the format HH:mmHH:mm.");
            }

            var startTimeStr = input.Substring(0, 5);
            var endTimeStr = input.Substring(5, 5);

            var startTime = TimeSpan.ParseExact(startTimeStr, "hh\\:mm", CultureInfo.InvariantCulture);
            var endTime = TimeSpan.ParseExact(endTimeStr, "hh\\:mm", CultureInfo.InvariantCulture);

            breakTimes.Add(new BreakTime(startTime, endTime));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid input format: {ex.Message}");
        }
    }

    public void AddBreakTimeFromFile(string[] lines)
    {
        foreach (var line in lines)
        {
            AddBreakTime(line);
        }
    }
}