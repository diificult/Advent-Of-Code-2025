using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Text;

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
            Dictionary<string,List<string>> paths = new Dictionary<string, List<string>>(); 

            foreach (string line in input) {

                var parts = line.Split(':');
                paths.Add(parts[0], parts[1].Split(' ').Skip(1).ToList());
            }

            int ans = findNextNode(paths, new List<string>(), "you");

            Console.WriteLine("Answer: " + ans);
            

    }


        public static int findNextNode(Dictionary<string, List<string>> paths, List<string> visitedNodes, string currentNode)
        {
            if (currentNode == "out") return 1;

           // if (visitedNodes.Contains(currentNode)) return 0; 

           // visitedNodes.Add(currentNode);

            int sum = 0;
            foreach (var nextNode in paths[currentNode])
            {
                sum += findNextNode(paths, visitedNodes, nextNode);
            }

            return sum;

        }


    public static void Part2(string[] input)
    {
    }
}
}
