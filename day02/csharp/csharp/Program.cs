using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

            string[] inputVals = ParseInput("../../../../input.txt", '\n');
            Console.WriteLine("Solution 2a: {0}", Solve2a(inputVals));
            Console.WriteLine("Solution 2b: {0}", Solve2b(inputVals));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void RunTests()
        {
            Debug.Assert(Solve2a(new string[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }) == 12, "Solve2a is Wrong!");
            Debug.Assert(Solve2b(new string[] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" }) == "fgij", "Solve2b is Wrong!");
        }

        static string[] ParseInput(string path, char splitBy)
        {
            return File.ReadAllText(path).Split(splitBy);
        }

        static int Solve2a(string[] input)
        {
            int foundTwoCounter = 0;
            int foundThreeCounter = 0;
            foreach (string s in input)
            {
                bool foundTwoTimes = false;
                bool foundThreeTimes = false;
                foreach (char c in s)
                {
                    if (!foundTwoTimes || !foundThreeTimes)
                    {
                        if (!foundTwoTimes && Regex.Matches(s, c.ToString()).Count == 2)
                        {
                            foundTwoCounter++;
                            foundTwoTimes = true;
                        }
                        if (!foundThreeTimes && Regex.Matches(s, c.ToString()).Count == 3)
                        {
                            foundThreeCounter++;
                            foundThreeTimes = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return foundTwoCounter * foundThreeCounter;
        }

        static bool IsDifferentByCharAmount(string a, string b, int amount)
        {
            int char_difference = 0;
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    char_difference++;
                    if (char_difference > amount)
                    {
                        return false;
                    }
                }
            }
            return char_difference == amount;
        }

        static string Solve2b(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i != j)
                    {
                        if (IsDifferentByCharAmount(input[i], input[j], 1))
                        {
                            return RemoveDifferentCharacters(input[i], input[j]);
                        }
                    }
                }
            }
            return string.Empty;
        }

        static string RemoveDifferentCharacters(string s1, string s2)
        {
            string s = string.Empty;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    s += s1[i];
                }
            }
            return s;
        }
    }
}
