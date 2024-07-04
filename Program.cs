using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        BreakTimeManager breakTimeManager = new BreakTimeManager();
        BreakTimeDisplay breakTimeDisplay = new BreakTimeDisplay();

        if (args.Length > 0 && args[0] == "filename" && args.Length > 1)
        {
            string filePath = args[1];
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                breakTimeManager.AddBreakTimeFromFile(lines);
            }
            else
            {
                Console.WriteLine($"File {filePath} not found.");
            }
        }

        breakTimeDisplay.DisplayBusiestPeriod(breakTimeManager.BreakTimes);

        while (true)
        {
            Console.WriteLine("Enter break time (format HH:mm-HH:mm) or type 'quit' to exit:");
            string? input = Console.ReadLine();  // input is nullable
            if (input == null || input.ToLower() == "quit") break;

            breakTimeManager.AddBreakTime(input);
            breakTimeDisplay.DisplayBusiestPeriod(breakTimeManager.BreakTimes);
        }
    }
}
