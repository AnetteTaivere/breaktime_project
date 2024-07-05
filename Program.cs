using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        BreakTimeManager breakTimeManager = new BreakTimeManager();
        BreakTimeDisplay breakTimeDisplay = new BreakTimeDisplay();
        while (true)
        {

            Console.WriteLine("Enter break time (format HH:mmHH:mm) or enter filename <path_to_file> or type 'quit' to exit");
            string? input = Console.ReadLine();  // input is nullable
            if (string.IsNullOrWhiteSpace(input) || input.Length == 0)
            {
                Console.WriteLine("Invalid input method.");
                continue;
            }
            if (input.ToLower() == "quit") break;

            if (input.Contains("filename", StringComparison.OrdinalIgnoreCase))
            {

                if (input.Split(' ').Length < 2 || !input.StartsWith("filename"))
                {
                    Console.WriteLine("Usage: filename <path_to_file>");
                    return;
                }

                string filePath = input.Split(' ')[1];

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File not found - {filePath}");
                    return;
                }

                try
                {
                    // Read the file and process each line
                    string[] lines = File.ReadAllLines(filePath);
                    breakTimeManager.AddBreakTimeFromFile(lines);
                    breakTimeDisplay.DisplayBusiestPeriod(breakTimeManager.BreakTimes);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading the file: {ex.Message}");
                }
            }
            else
            {
                if (input.Length != 10 || input[2] != ':' || input[7] != ':')
                {
                    Console.WriteLine("Invalid date format!");
                }
                else
                {
                    breakTimeManager.AddBreakTime(input);
                    breakTimeDisplay.DisplayBusiestPeriod(breakTimeManager.BreakTimes);
                }
            }
        }
    }
}
