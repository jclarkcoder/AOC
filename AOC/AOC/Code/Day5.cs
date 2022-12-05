using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC.Code
{
    public class Day5: IAocDay
    {     
        public void Part1()
        {
            var stacks = BuildInitialStacks();
            stacks = PerformMovements(stacks, false);
            PrintTopOfStacks(stacks);
        }

        public void Part2()
        {
            var stacks = BuildInitialStacks();
            stacks = PerformMovements(stacks, true);
            PrintTopOfStacks(stacks);
        }

        private List<Stack<char>> BuildInitialStacks()
        {
            var lines = File.ReadAllLines("Inputs\\Day5.txt");
            var stacks = new List<Stack<char>> { };
            
            lines = lines.Reverse().ToArray();

            foreach (var line in lines)
            {
                if (line.Contains('['))
                {
                    var indexCount = 1;

                    for (int i = 1; i < line.Length; i += 4)
                    {
                        var c = line[i];

                        if (stacks.Count() < indexCount)
                        {
                            stacks.Add(new Stack<char>());
                        }

                        if (c != ' ') { 
                        stacks[indexCount - 1].Push(c);
                    }

                        indexCount += 1;                      
                    }
                }
            }
                return stacks;
        }

        private List<Stack<char>> PerformMovements(List<Stack<char>> stacks, bool selectMultiple)
        {
            var lines = File.ReadAllLines("Inputs\\Day5.txt");

            foreach (var line in lines)
            {
                if (line.Contains("move"))
                {
                    var parsedLine = line.Replace("move", "").Replace("from", "").Replace("to", "").Trim();
                    var tokens = parsedLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var count =  Convert.ToInt32(tokens[0]);
                    var from = Convert.ToInt32(tokens[1]) - 1;
                    var to = Convert.ToInt32(tokens[2]) - 1;

                    Swap(stacks[from], stacks[to], count, selectMultiple);
                }
            }

            return stacks;
        }

        private void Swap(Stack<char> x, Stack<char> y, int count, bool selectMultiple)
        {
            if (selectMultiple)
            {
                var chars = new List<char>();

                for (int i = 0; i < count; i++)
                {
                    chars.Add(x.Pop());
                }

                chars.Reverse();

                foreach (char c in chars)
                {
                    y.Push(c);
                }
            } else
            {
                for(int i = 0; i < count; i++)
                {
                    y.Push(x.Pop());
                }
            }
        }

        private void PrintTopOfStacks(List<Stack<char>> stacks)
        {
            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek());
            }

            Console.WriteLine();
        }
    }
}
