using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

/*! Day1
*   http://adventofcode.com/2018/day/1
*/

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();

            int[] inputVals = ParseInput("../../../../input.txt", '\n');
            Console.WriteLine("Solution 1a: {0}", Solve1a(inputVals));
            Console.WriteLine("Solution 1b: {0}", Solve1b(inputVals));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void RunTests()
        {
            // Solve01
            Debug.Assert(Solve1a(new int[] { +1, -2, +3, +1 }) == 3, "Solve1a is Wrong! for `+1, -2, +3, +1`");
            Debug.Assert(Solve1a(new int[] { +1, +1, -2 }) == 0, "Solve1a is Wrong! for `+1, +1, -2`");
            Debug.Assert(Solve1a(new int[] { -1, -2, -3 }) == -6, "Solve1a is Wrong! for `-1, -2, -3`");

            // Solve02
            Debug.Assert(Solve1b(new int[] { +3, +3, +4, -2, -4 }) == 10, "Solve1b is Wrong! for `+3, +3, +4, -2, -4`");
            Debug.Assert(Solve1b(new int[] { -6, +3, +8, +5, -6 }) == 5, "Solve1b is Wrong! for `-6, +3, +8, +5, -6`");
            Debug.Assert(Solve1b(new int[] { +7, +7, -2, -7, -4 }) == 14, "Solve1b is Wrong! for `+7, +7, -2, -7, -4`");
        }

        static int[] ParseInput(string path, char splitBy)
        {
            string[] input = File.ReadAllText(path).Split(splitBy);
            int[] inputVals = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                inputVals[i] = int.Parse(input[i]);
            }
            return inputVals;
        }

        static int Solve1a(int[] input)
        {
            int runningSum = 0;
            foreach (int i in input)
            {
                runningSum += i;
            }
            return runningSum;
        }

        static int Solve1b(int[] input)
        {
            Dictionary<int, bool> seenDict = new Dictionary<int, bool>();
            seenDict.Add(0, true);
            return Solve1b(input, seenDict);
        }

        static int Solve1b(int[] input, Dictionary<int, bool> seenDict, int prevRunningSum = 0)
        {
            int runningSum = prevRunningSum;
            foreach (int i in input)
            {
                runningSum += i;
                if (seenDict.ContainsKey(runningSum))
                {
                    return runningSum;
                }
                else
                {
                    seenDict.Add(runningSum, true);
                }
            }
            return Solve1b(input, seenDict, runningSum);
        }
    }
}
