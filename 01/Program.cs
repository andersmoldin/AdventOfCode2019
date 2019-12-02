using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/1
        /// </summary>
        private static int Part1(IEnumerable<string> masses)
        {
            return masses.Select(mass => ((int)Math.Floor(double.Parse(mass) / 3)) - 2).Sum();
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/1#part2
        /// </summary>
        private static int Part2(IEnumerable<string> changes)
        {
            throw new NotImplementedException();
        }
    }
}