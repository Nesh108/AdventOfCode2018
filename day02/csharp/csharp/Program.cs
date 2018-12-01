using System;
using System.Diagnostics;
using System.IO;

/*! Day2
*   http://adventofcode.com/2018/day/2
*/

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();

            int[] inputVals = ParseInput("../../../../input.txt", '\n');
            Console.WriteLine("Solution 2a: {0}", Solve2a(inputVals));
            Console.WriteLine("Solution 2b: {0}", Solve2b(inputVals));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void RunTests()
        {
            // Solve01
            Debug.Assert(Solve2a(new int[] { }) == 0, "Solve2a is Wrong! for ``");

            // Solve02
            Debug.Assert(Solve2b(new int[] { }) == 0, "Solve2b is Wrong! for ``");
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

        static int Solve2a(int[] input)
        {
            return 0;
        }

        static int Solve2b(int[] input)
        {
            return 0;
        }
    }
}
