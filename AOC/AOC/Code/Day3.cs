namespace AOC.Code
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    namespace AOC
    {
        public class Day3: IAocDay
        {
            public void Part1()
            {
                
                var lines = File.ReadAllLines("Inputs\\Day3.txt");
                List<int> priorities = new List<int>();
             
                foreach(var line in lines)
                {
                    var halfLenth = line.Length / 2;
                    var firstHalf = line.Substring(0, halfLenth);
                    var secondHalf = line.Substring(line.Length / 2, line.Length - halfLenth);
                    var first = firstHalf.ToCharArray();
                    var second = secondHalf.ToCharArray();

                    var common = first.Where(it => second.Contains(it)).Distinct();
                    int priority = common.Sum(it =>  + (Char.IsLower(it) ? -96 : (26 + (- 64))) + it);
                    priorities.Add(priority);
                                               
                }
                Console.WriteLine(priorities.Sum());
            }

            public void Part2()
            {
                var lines = File.ReadAllLines("Inputs\\Day3.txt");
                List<int> priorities = new List<int>();
                var i = 0;
                foreach (var line in lines)
                {
                    i += 1;
                    if (i > 0 && i % 3 == 0)
                    {
                        var line1 = lines[i - 3];
                        var line2 = lines[i - 2];
                        var common = (line1.Where(it => line2.Contains(it))).Where(it => line.Contains(it)).Distinct();
                        int priority = common.Sum(it => +(Char.IsLower(it) ? -96 : (26 + (-64))) + it);
                        priorities.Add(priority);
                    }

                  
                }
                Console.WriteLine(priorities.Sum());               
            }            
        }
    }

}
