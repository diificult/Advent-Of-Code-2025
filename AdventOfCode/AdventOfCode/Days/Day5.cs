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

            //Possible further improvement: Bring in the sort and merge, then do a better type of search.
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

        public static void Part2(string[] input)
        {
            var ranges = new List<(long start, long end)>();

            long ans = 0;

            foreach (string line in input)
            {

                if (string.IsNullOrWhiteSpace(line))
                {
               
                    break;
                }

                string[] parts = line.Split('-');
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                ranges.Add((start, end));

            }
            ranges.Sort((a,b) => a.start.CompareTo(b.start));

            var mergedRanges = new List<(long start, long end)>();

            foreach(var r in ranges)
            {
                if (mergedRanges.Count == 0)
                {
                    mergedRanges.Add(r);
                    continue;
                }

                var last = mergedRanges[^1];
                if (r.start <= last.end+1) 
                {
                    mergedRanges[^1] = (last.start, Math.Max(r.end, last.end));
                }
                else
                {
                    mergedRanges.Add(r);
                }

            }

            foreach (var r in mergedRanges)
            {
                ans += r.end - r.start + 1;
            }

           

            Console.WriteLine("Answer: " + ans);
        }
    }
}
