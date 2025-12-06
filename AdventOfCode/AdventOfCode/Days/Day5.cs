using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day5
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(5));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(5));
            }
        }

        public static void Part1(string[] input)
        {
            var ranges = new List<(long start, long end)>();

            List<long> checkIds = new List<long>();

            bool atChecks = false;

            int ans = 0;

            int i = 0;
            foreach (string line in input)
            {


                if (atChecks)
                {
                    checkIds.Add(long.Parse(line));
                    continue;
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    atChecks = true;
                    continue;
                }

                string[] parts = line.Split('-');
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                ranges.Add((start, end));

            }

            //Possible further improvement could sort then merge
            foreach (long checkId in checkIds)
            {
                foreach (var (start,end) in ranges)
                {
                    if (checkId >= start && checkId <= end)
                    {
                        ans++;
                        break;
                    }
                }
            }

            Console.WriteLine("Answer: " + ans);
        }


        //Going to need to sort and merge them now lol.
        public static void Part2(string[] input)
        {
        }
    }
}
