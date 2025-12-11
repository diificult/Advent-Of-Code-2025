
using AdventOfCode.Days;
using System.Diagnostics;

int dayNo = 10;
int partNo = 1;


Console.WriteLine("[ENTER A NUMBER] Which day would you like to do? (hit enter for latest)");
string? dayInput = Console.ReadLine();

Console.WriteLine("[ENTER A NUMBER] Which part would you like to do? (hit enter for latest)");
string? partInput = Console.ReadLine();

int day = string.IsNullOrWhiteSpace(dayInput)
    ? dayNo
    : int.TryParse(dayInput, out var d) ? d : dayNo;

int part = string.IsNullOrWhiteSpace(partInput)
    ? partNo
    : int.TryParse(partInput, out var p) ? p : partNo;


RunDay(day, part);

static void RunDay(int day, int part)
{
    var watch = Stopwatch.StartNew();
    switch (day)
    {
        case 1: Day1.Run(); break;
        case 2: Day2.Run(); break;
        case 3: Day3.Run(part); break;
        case 4: Day4.Run(part); break;
        case 5: Day5.Run(part); break;
        case 6: Day6.Run(part); break;
        case 7: Day7.Run(part); break;
        case 8: Day8.Run(part); break;
        case 9: Day9.Run(part); break;
        case 10: Day10.Run(part); break;
        default:
            Console.WriteLine($"Day {day} is not implemented.");
            break;
    }
    watch.Stop();
    Console.WriteLine("TimeTaken: " + watch.Elapsed);
}

