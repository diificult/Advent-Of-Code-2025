using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day6
    {

        public static void Run(int part)
        {
            {
                if (part == 1)
                {
                    Part1(InputReader.ReadInputLines(6));
                }
                else if (part == 2)
                {
                    Part2(InputReader.ReadInputLines(6));
                }
            }

        }
        public static void Part1(string[] input)
        {

            var numbers = new List<List<long>>();

            foreach (var line in input.SkipLast(1))
            {
                var lineSplit = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(z => long.Parse(z)).ToList();
                numbers.Add(lineSplit);
            }

            var summing = input[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => (c, c == "+" ? 0l : 1l)).ToList();

            foreach (var line in numbers)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    summing[i] = (summing[i].c ,summing[i].c == "+" ? summing[i].Item2 + line[i] : summing[i].Item2 * line[i]);
                }
            }

            long ans = 0;
            foreach (var sum in summing)
            {
                ans += sum.Item2;
            }
            Console.WriteLine("Answer: " + ans);


        }

        public static void Part2(string[] input)
        {
        }
    }
}
