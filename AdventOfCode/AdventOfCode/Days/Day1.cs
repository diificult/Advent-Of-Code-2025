
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day1
    {
        public static void Run()
        {
            var input = InputReader.ReadInputLines(1);
            
            int location = 50;

            int password = 0;

            foreach (var line in input)
            {
                char rotation = line[0];
                int distance = int.Parse(line.Substring(1));

                int startLocation = location;

                location = rotation == 'R' ? location + distance : location - distance;

                while (location < 0 ) location = 100 + location;
                if (location > 99 ) location = location % 100;

                if (location == 0) password++; 
                Console.WriteLine($"Rotation: {rotation}, Distance: {distance}, StartLocation: {startLocation}, EndLocation: {location}");
            }

            Console.WriteLine("Answer: " + password);


        }
    }
}