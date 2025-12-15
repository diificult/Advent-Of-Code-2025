using AdventOfCode.Common;
using System.ComponentModel;

namespace AdventOfCode.Days
{
    public class Day11
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(11));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(11));
            }
        }

        public static void Part1(string[] input)
        {
            Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();

            foreach (string line in input)
            {

                var parts = line.Split(':');
                paths.Add(parts[0], parts[1].Split(' ').Skip(1).ToList());
            }

            int ans = findNextNodePart1(paths, new List<string>(), "you");

            Console.WriteLine("Answer: " + ans);


        }


        public static int findNextNodePart1(Dictionary<string, List<string>> paths, List<string> visitedNodes, string currentNode)
        {
            if (currentNode == "out") return 1;

            int sum = 0;
            foreach (var nextNode in paths[currentNode])
            {
                sum += findNextNodePart1(paths, visitedNodes, nextNode);
            }

            return sum;

        }


        public static void Part2(string[] input)
        {
            // simple adjacency map
            Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();

            foreach (string line in input)
            {
                var parts = line.Split(':');
                paths.Add(parts[0], parts[1].Split(' ').Skip(1).ToList());
            }

            // memo keyed by (node, visitedDac, visitedFFT)
            var memo = new Dictionary<(string node, bool dac, bool fft), long>();
            var visited = new HashSet<string>();

            long ans = findNextNodePart2(paths, visited, memo, false, false, "svr");

            Console.WriteLine("Answer: " + ans);
        }

        public static long findNextNodePart2(
            Dictionary<string, List<string>> paths,
            HashSet<string> visited,
            Dictionary<(string node, bool dac, bool fft), long> memo,
            bool visitedDac,
            bool visitedfft,
            string currentNode)
        {
            if (currentNode == "out")
            {
                return (visitedDac && visitedfft) ? 1 : 0;
            }

            if (visited.Contains(currentNode)) return 0;

            var key = (currentNode, visitedDac, visitedfft);
            if (memo.TryGetValue(key, out var cached)) return cached;

            if (currentNode == "dac") visitedDac = true;
            else if (currentNode == "fft") visitedfft = true;

            long sum = 0;
            visited.Add(currentNode);
            try
            {
                if (paths.TryGetValue(currentNode, out var neighbors))
                {
                    foreach (var next in neighbors)
                    {
                        sum += findNextNodePart2(paths, visited, memo, visitedDac, visitedfft, next);
                    }
                }
            }
            finally
            {
                visited.Remove(currentNode);
            }

            memo[key] = sum;
            return sum;
        }

    }
}
