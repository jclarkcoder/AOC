using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Code
{
    public class Day2: IAocDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("Inputs\\Day2.txt");
            var total = 0;
            foreach(var line in lines)
            {
                var tokens = line.Split(' ');
                var opponent = tokens[0];
                var mymove = tokens[1];
                total += GetScore(opponent, mymove);
            }

            Console.WriteLine(total);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("Inputs\\Day2.txt");
            var total = 0;
            foreach (var line in lines)
            {
                var tokens = line.Split(' ');
                var opponent = tokens[0];
                var mymove = tokens[1];
                total += GetRequiredMoveAndScore(opponent, mymove);
            }

            Console.WriteLine(total);
        }

        private int GetScore(string oppoent, string me)
        {
            int score = 0;
            switch (oppoent)
            {
                case "A":
                    switch (me)
                    {
                        case "X":
                            score = (1 + 3);
                            break;
                        case "Y":
                            score = (2 + 6);
                            break;
                        case "Z":
                            score = 3;
                            break;
                    }

                    break;

                case "B":
                    switch (me)
                    {
                        case "X":
                            score = 1;
                            break;
                        case "Y":
                            score = (2 + 3);
                            break;
                        case "Z":
                            score = (3 + 6);
                            break;
                    }

                    break;

                case "C":
                    switch (me)
                    {
                        case "X":
                            score = (1 + 6);
                            break;
                        case "Y":
                            score = 2;
                            break;
                        case "Z":
                            score = 3 + 3;
                            break;
                    }

                    break;
            }

            return score;
        }

        private int GetRequiredMoveAndScore(string opponent, string me)
        {
            if (me == "Y")
            {
                switch (opponent)
                {
                    case "A":
                        return GetScore(opponent, "X");
                    case "B":
                        return GetScore(opponent, "Y");
                    case "C":
                        return GetScore(opponent, "Z");
                }
            }

            var x = GetScore(opponent, "X");
            var y =   GetScore(opponent, "Y");
            var z = GetScore(opponent, "Z");      

            if (me == "X")
            {
             return Math.Min(Math.Min(x, y), z);
            } else
            {
              return Math.Max(Math.Max(x, y), z);
            }
        }
    }
}
