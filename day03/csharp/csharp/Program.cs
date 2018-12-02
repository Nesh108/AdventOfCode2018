using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

/*! Day3
*   http://adventofcode.com/2018/day/3
*/

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();

            string[] inputVals = ParseInputAsString("../../../../input.txt", '\n');
            Console.WriteLine("Solution 3a: {0}", Solve3a(inputVals));
            Console.WriteLine("Solution 3b: {0}", Solve3b(inputVals));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void RunTests()
        {
            Debug.Assert(Solve3a(new string[] { }) == 12, "Solve2a is Wrong!");
            Debug.Assert(Solve3b(new string[] { }) == "", "Solve2b is Wrong!");
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

        static string[] ParseInputAsString(string path, char splitBy)
        {
            return File.ReadAllText(path).Split(splitBy);
        }

        static string[] ParseInputPerChar(string path)
        {
            return File.ReadAllText(path).ToCharArray().Select(c => c.ToString()).ToArray(); ;
        }

        static int Solve3a(string[] input)
        {
            return 0;
        }
        static string Solve3b(string[] input)
        {
            return "";
        }
    }
}
