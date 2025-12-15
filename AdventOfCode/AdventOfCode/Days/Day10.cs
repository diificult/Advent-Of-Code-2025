using AdventOfCode.Common;

namespace AdventOfCode.Days
{

    public record Machine(bool[] switchTargets, List<List<int>> buttons, int[] joltageTargets) { } //ignoring joltages for now
    public class Day10
    {



        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(10));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(10));
            }
        }



        public static void Part1(string[] input)
        {

            var machines = new List<Machine>();

            foreach (string line in input)
            {
                var parts = line.Split(" ").ToList();
                bool[] targets = parts[0].Trim(new char[] { '[', ']' }).ToList().Select(s => s == '#' ? true : false).ToArray();

                var buttons = parts.Skip(1).SkipLast(1).Select(p => p.Trim(new char[] { '(', ')' }).Split(',').Select(b => int.Parse(b)).ToList()).ToList();

                var Machine = new Machine(targets, buttons, null);
                machines.Add(Machine);
            }
            int answer = 0;


            foreach (var machine in machines)
            {
                List<bool[]> states = new List<bool[]>();
                states.Add(new bool[machine.switchTargets.Length]);

                var newStates = new List<bool[]>();

                int switchesDone = 0;

                while (!states.Any(s => s.SequenceEqual(machine.switchTargets)))
                {
                    foreach (var buttons in machine.buttons)
                    {
                        foreach (var state in states)
                        {

                            var updatedState = state.Select(s => s).ToArray();
                            var changeLights = switchLights(updatedState, buttons);
                            newStates.Add(changeLights);

                        }

                    }
                    states = newStates.DistinctBy(arr => string.Join(",", arr)).ToList();
                    switchesDone++;
                }
                answer += switchesDone;
            }
            Console.WriteLine("Answer: " + answer);

        }
        public static bool[] switchLights(bool[] input, List<int> buttons)
        {
            foreach (var button in buttons)
            {
                input[button] = !input[button];
            }

            return input;
        }

        public static void Part2(string[] input)
        {

            var machines = new List<Machine>();

            foreach (string line in input)
            {
                var parts = line.Split(" ").ToList();
                int[] targets = parts[^1].Trim(new char[] { '{', '}' }).Split(',').Select(s => int.Parse(s)).ToArray();

                var buttons = parts.Skip(1).SkipLast(1).Select(p => p.Trim(new char[] { '(', ')' }).Split(',').Select(b => int.Parse(b)).ToList()).ToList();

                var Machine = new Machine(null, buttons, targets);
                machines.Add(Machine);
            }
            int answer = 0;


            foreach (var machine in machines)
            {
                List<int[]> states = new List<int[]>();
                states.Add(new int[machine.joltageTargets.Length]);


                int switchesDone = 0;

                while (!states.Any(s => s.SequenceEqual(machine.joltageTargets)))
                {

                    var newStates = new List<int[]>();
                    states = states .Where(s => s.Zip(machine.joltageTargets, (x, t) => x <= t).All(z => z)).ToList();
                    foreach (var buttons in machine.buttons)
                    {
                        foreach (var state in states)
                        {

                            var updatedState = state.Select(s => s).ToArray();
                            var changeJoltage = updateJoltage(updatedState, buttons);
                            newStates.Add(changeJoltage);

                        }

                    }
                    states = newStates.DistinctBy(arr => string.Join(",", arr)).ToList();
                    switchesDone++;
                }
                answer += switchesDone;
            }
            Console.WriteLine("Answer: " + answer);

        }

        public static int[] updateJoltage(int[] input, List<int> buttons)
        {

            foreach (var button in buttons)
            {
                input[button] ++;
            }

            return input;

        }
    }
}
