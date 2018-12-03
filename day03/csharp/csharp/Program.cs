using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            bool[] overlappedIDs = null;
            Console.WriteLine("Solution 3a: {0}", Solve3a("../../../../input.txt", '\n', ref overlappedIDs));
            Console.WriteLine("Solution 3b: {0}", Solve3b(overlappedIDs));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int Solve3a(string path, char splitBy, ref bool[] overlappedIDs)
        {
            string[] input = File.ReadAllText(path).Split(splitBy);

            overlappedIDs = new bool[input.Length];
            int count = 0;
            Dictionary<Point, int> fabricArea = new Dictionary<Point, int>();
            Dictionary<Point, bool> fabricCounted = new Dictionary<Point, bool>();
            
            for (int i = 0; i < input.Length; i++)
            {
                string[] v = input[i].Split(' ');
                Rectangle r = new Rectangle(
                    new Point(int.Parse(v[2].Split(':')[0].Split(',')[0]), int.Parse(v[2].Split(':')[0].Split(',')[1])),
                    new Size(int.Parse(v[3].Split('x')[0]), int.Parse(v[3].Split('x')[1]))
                );

                for (int x = r.Location.X; x < r.Width + r.Location.X; x++)
                {
                    for (int y = r.Location.Y; y < r.Height + r.Location.Y; y++)
                    {
                        Point pixel = new Point(x, y);
                        if (!fabricCounted.ContainsKey(pixel))
                        {
                            if (fabricArea.ContainsKey(pixel))
                            {
                                count++;
                                fabricCounted.Add(pixel, true);
                                overlappedIDs[i] = true;
                                overlappedIDs[fabricArea[pixel]] = true;
                            }
                            else
                            {
                                fabricArea.Add(pixel, i);
                            }
                        }
                        else
                        {
                            overlappedIDs[i] = true;
                            overlappedIDs[fabricArea[pixel]] = true;
                        }
                    }
                }
            }
            return count;
        }

        static int Solve3b(bool[] overlappedIDs)
        {
            for (int i = 0; i < overlappedIDs.Length; i++)
            {
                if (!overlappedIDs[i])
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
