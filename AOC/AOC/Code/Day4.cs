using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC.Code
{
    class Day4
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("Inputs\\Day4.txt");
            int count = 0;
            foreach(var line in lines)
            {
                var elves = line.Split(',');

                var firstRange = elves[0].Split('-');
                var secondRange = elves[1].Split('-');

                var firstRangeStart = Convert.ToInt32(firstRange[0]);
                var firstRangeEnd = Convert.ToInt32(firstRange[1]);

                var secondRangeStart = Convert.ToInt32(secondRange[0]);
                var seconRangeEnd = Convert.ToInt32(secondRange[1]);

                if(firstRangeStart >= secondRangeStart && firstRangeEnd <= seconRangeEnd)
                {
                    count += 1;
                } else if (secondRangeStart >= firstRangeStart && seconRangeEnd <= firstRangeEnd)
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
           
        }
     

        public void Part2()
        {
            var lines = File.ReadAllLines("Inputs\\Day4.txt");
            int count = 0;
            foreach (var line in lines)
            {
                var elves = line.Split(',');

                var firstRange = elves[0].Split('-');
                var secondRange = elves[1].Split('-');

                var firstRangeStart = Convert.ToInt32(firstRange[0]);
                var firstRangeEnd = Convert.ToInt32(firstRange[1]);

                var secondRangeStart = Convert.ToInt32(secondRange[0]);
                var seconRangeEnd = Convert.ToInt32(secondRange[1]);

                // max of first < min - second
                //min of

                var firstList = Enumerable.Range(firstRangeStart, (firstRangeEnd - firstRangeStart) + 1);
                var secondList = Enumerable.Range(secondRangeStart, (seconRangeEnd - secondRangeStart) + 1);

                if(firstList.Any(it => secondList.Contains(it)))
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
        }
    }
}
