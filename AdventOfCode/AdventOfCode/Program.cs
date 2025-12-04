
using AdventOfCode.Days;

int dayNo = 4;
int partNo = 2;


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
    switch (day)
    {
        case 1: Day1.Run(); break;
        case 2: Day2.Run(); break;
        case 3: Day3.Run(part); break;
        case 4: Day4.Run(part); break;
        default:
            Console.WriteLine($"Day {day} is not implemented.");
            break;
    }
}

