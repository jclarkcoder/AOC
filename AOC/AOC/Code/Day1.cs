using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC
{
    public class Day1 : IAocDay
    {
        public void Part1()
        {
            var totals = GetSortedTotals();
            Console.WriteLine(totals.First());
        }

        public void Part2()
        {
            var totals = GetSortedTotals();
            Console.WriteLine(totals[0] + totals[1] + totals[2]);
        }

        public List<int> GetSortedTotals()
        {

            var lines = File.ReadAllLines("Inputs\\Day1.txt");
            var calories = new List<int>();
            var totals = new List<int>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var total = calories.Sum();
                    totals.Add(total);
                    calories.Clear();
                }
                else
                {
                    calories.Add(Convert.ToInt32(line));
                }
            }

            return totals.OrderByDescending(it => it).ToList();
            
        }
    }
}
