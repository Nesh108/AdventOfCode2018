using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/*! Day4
*   http://adventofcode.com/2018/day/5
*/

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution 5a: {0}", Solve5a(File.ReadAllText("../../../../input.txt")));
            Console.WriteLine("Solution 5b: {0}", Solve5b(File.ReadAllText("../../../../input.txt")));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
        static int Solve5a(string input)
        {
            bool isDone = false;
            char[] array = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            while (!isDone)
            {
                string newInput = input;
                foreach (char c in array)
                {
                    newInput = newInput.Replace(c.ToString() + c.ToString().ToLower(), "");
                    newInput = newInput.Replace(c.ToString().ToLower() + c.ToString(), "");
                }
                if (newInput.Length == input.Length)
                {
                    isDone = true;
                }
                else
                {
                    input = newInput;
                }
            }
            return input.Length;
        }

        static int Solve5b(string input)
        {
            char[] array = " ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            ArrayList sizes = new ArrayList();
            Task[] tasks = new Task[array.Length];
            int idx = 0;
            foreach (char c in array)
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    sizes.Add(Solve5b(input, c));
                });
                tasks[idx] = t;
                idx++;
            }

            Task.WaitAll(tasks);
            int shortest = input.Length;
            foreach (int s in sizes)
            {
                shortest = Math.Min(shortest, s);
            }
            return shortest;
        }

        static int Solve5b(string input, char cc)
        {
            input = input.Replace(cc.ToString(), "");
            input = input.Replace(cc.ToString().ToLower(), "");
            return Solve5a(input);
        }
    }
}
