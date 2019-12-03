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
            var input = File.ReadLines("input.txt").Select(int.Parse).ToList();

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/1
        /// </summary>
        private static int Part1(IEnumerable<int> masses)
        {
            return masses.Select(mass => GetFuelForMass(mass)).Sum();
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/1#part2
        /// </summary>
        private static int Part2(IEnumerable<int> masses)
        {
            return masses.ToList().Select(mass => GetFuelForFuelAndMass(mass)).Sum();
        }

        private static int GetFuelForMass(int mass)
        {
            return (int)(Math.Floor((double)mass / 3)) - 2;
        }

        private static int GetFuelForFuelAndMass(int mass)
        {
            var sum = (int)(Math.Floor((double)mass / 3)) - 2;

            if (sum <= 0)
                return 0;

            return sum + GetFuelForFuelAndMass(sum);
        }
    }
}