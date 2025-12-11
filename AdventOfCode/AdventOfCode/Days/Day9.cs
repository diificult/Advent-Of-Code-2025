using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day9
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(9));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(9));
            }
        }

        public static void Part1(string[] input)
        {

            var positions = new List<(int x, int y)>();
            foreach (var line in input)
            {
                var coords = line.Trim().Split(',');
                positions.Add((int.Parse(coords[0]), int.Parse(coords[1])));
            }
            long biggestRectSize = 0;
            for (int x = 0; x < positions.Count; x++)
            {
                for (int y = x + 1; y < positions.Count; y++)
                {
                    biggestRectSize = Math.Max(biggestRectSize, rectSize(positions[x], positions[y]));

                }
            }

            Console.WriteLine("Answer: " + biggestRectSize);



        }

        public static long rectSize((int x, int y) left, (int x, int y) right)
        {
            long width = Math.Abs(left.x - right.x) + 1;
            long height = Math.Abs(left.y - right.y) + 1;
            return width * height;

        }



        public static void Part2(string[] input)
        {
        }
    }
}
