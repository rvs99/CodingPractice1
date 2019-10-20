using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    class Program
    {
        private static int[] x = { 70, 80, 90, 100, 10, 20, 30, 40, 50, 60 };
        private static int[] y = { 55, 65, 75, 85, 95, 105, 5, 15, 25, 35, 45 };
        private static int target = 155;

        static void Main(string[] args)
        {
            Array.Sort(x);
            Array.Sort(y);

            List<Tuple<int, int, int>> nearestPairs = FindNearestPair(x.Length / 2, y.Length / 2);

            Console.ReadLine();
        }


        private static List<Tuple<int, int, int>> FindNearestPair(int seedX, int seedY)
        {
            List<Tuple<int, int, int>> nearestPair = new List<Tuple<int, int, int>>();

            if (x[seedX] + y[seedY] == target)
            {
                nearestPair.Add(new Tuple<int, int, int>(seedX, seedY, x[seedX] + y[seedY]));
            }
            else if (x[seedX] + y[seedY] > target)
            {
                if (seedX >= 0)
                    nearestPair.AddRange(FindNearestPair(seedX - 1, seedY));
                if (seedY >= 0)
                    nearestPair.AddRange(FindNearestPair(seedX, seedY - 1));
            }
            else
            {
                if (seedX + 1 < x.Length)
                    nearestPair.AddRange(FindNearestPair(seedX + 1, seedY));
                if (seedY + 1 < y.Length)
                    nearestPair.AddRange(FindNearestPair(seedX, seedY + 1));
            }
            return nearestPair;
        }
    }
}
