using System;
using System.Collections.Generic;
using System.IO;

/*! Day4
*   http://adventofcode.com/2018/day/4
*/

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution 4a: {0}", Solve4a("../../../../input.txt", '\n'));
            Console.WriteLine("Solution 4b: {0}", Solve4b("../../../../input.txt", '\n'));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int Solve4a(string path, char splitBy)
        {
            string[] input = File.ReadAllText(path).Split(splitBy);

            Array.Sort(input, StringComparer.InvariantCulture);
            int maxSleep = 0;
            int maxGuardID = -1;
            int curGuardID = -1;
            int sleepStart = 0;
            int curSleep = 0;
            string inpVal;
            Dictionary<int, int> vals = new Dictionary<int, int>();
            Dictionary<int, int> guards = new Dictionary<int, int>();
            DateTime dt;
            for (int i = 0; i < input.Length; i++)
            {
                dt = DateTime.ParseExact(input[i].Split('[')[1].Split(']')[0], "yyyy-MM-dd HH:mm", null);
                inpVal = input[i].Split(']')[1].Split(' ')[1];
                if (inpVal == "Guard")
                {
                    int id = int.Parse(input[i].Split(']')[1].Split(' ')[2].Split('#')[1]);
                    if (curGuardID != id)
                    {
                        curGuardID = id;
                        curSleep = 0;
                    }
                }
                else if (inpVal == "falls")
                {
                    sleepStart = dt.Minute;
                }
                else if (inpVal == "wakes")
                {
                    curSleep = Math.Abs((dt.Minute - 1) - sleepStart);
                    if (guards.ContainsKey(curGuardID))
                    {
                        guards[curGuardID] = guards[curGuardID] + curSleep;
                    }
                    else
                    {
                        guards.Add(curGuardID, curSleep);
                    }
                }
            }

            foreach (KeyValuePair<int, int> g in guards)
            {
                if (g.Value > maxSleep)
                {
                    maxSleep = g.Value;
                    maxGuardID = g.Key;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                dt = DateTime.ParseExact(input[i].Split('[')[1].Split(']')[0], "yyyy-MM-dd HH:mm", null);
                inpVal = input[i].Split(']')[1].Split(' ')[1];
                if (inpVal == "Guard")
                {
                    curGuardID = int.Parse(input[i].Split(']')[1].Split(' ')[2].Split('#')[1]);
                }
                else if (curGuardID == maxGuardID && inpVal == "falls")
                {
                    sleepStart = dt.Minute;
                }
                else if (curGuardID == maxGuardID && inpVal == "wakes")
                {
                    for (int j = sleepStart; j < dt.Minute; j++)
                    {
                        if (vals.ContainsKey(j))
                        {
                            vals[j] = vals[j] + 1;
                        }
                        else
                        {
                            vals.Add(j, 1);
                        }
                    }
                }
            }
            int maxVal = -1;
            int maxKey = -1;
            foreach (KeyValuePair<int, int> val in vals)
            {
                if (val.Value > maxVal)
                {
                    maxVal = val.Value;
                    maxKey = val.Key;
                }
            }
            return maxKey * maxGuardID;
        }

        static int Solve4b(string path, char splitBy)
        {
            string[] input = File.ReadAllText(path).Split(splitBy);
            Array.Sort(input, StringComparer.InvariantCulture);
            int curGuardID = -1;
            int sleepStart = 0;
            string inpVal;
            Dictionary<string, int> minutes = new Dictionary<string, int>();
            Dictionary<int, int> guards = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                DateTime dt = DateTime.ParseExact(input[i].Split('[')[1].Split(']')[0], "yyyy-MM-dd HH:mm", null);
                inpVal = input[i].Split(']')[1].Split(' ')[1];
                if (inpVal == "Guard")
                {
                    int id = int.Parse(input[i].Split(']')[1].Split(' ')[2].Split('#')[1]);
                    if (curGuardID != id)
                    {
                        curGuardID = id;
                    }
                }
                else if (inpVal == "falls")
                {
                    sleepStart = dt.Minute;
                }
                else if (inpVal == "wakes")
                {
                    for (int j = sleepStart; j < dt.Minute; j++)
                    {
                        if (minutes.ContainsKey(curGuardID + ";" + j))
                        {
                            minutes[curGuardID + ";" + j] = minutes[curGuardID + ";" + j] + 1;
                        }
                        else
                        {
                            minutes.Add(curGuardID + ";" + j, 1);
                        }
                    }
                }
            }

            int maxVal = -1;
            int maxMin = -1;
            int maxGuardID = -1;
            foreach (KeyValuePair<string, int> m in minutes)
            {
                if (m.Value > maxVal)
                {
                    maxVal = m.Value;
                    string[] v = m.Key.Split(';');
                    maxGuardID = int.Parse(v[0]);
                    maxMin = int.Parse(v[1]);
                }
            }
            return maxMin * maxGuardID;
        }
    }
}
