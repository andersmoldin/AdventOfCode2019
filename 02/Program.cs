using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split(",").Select(int.Parse).ToList();
            
            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/2
        /// </summary>
        private static int Part1(List<int> input)
        {
            var opcodes = input.ToList();
            int currentPosition = 0;
            opcodes[1] = 12;
            opcodes[2] = 2;

            while (opcodes[currentPosition] != 99)
            {
                switch (opcodes[currentPosition])
                {
                    case 1:
                        opcodes[opcodes[currentPosition + 3]] = opcodes[opcodes[currentPosition + 1]] + opcodes[opcodes[currentPosition + 2]];
                        currentPosition += 4;
                        break;
                    case 2:
                        opcodes[opcodes[currentPosition + 3]] = opcodes[opcodes[currentPosition + 1]] * opcodes[opcodes[currentPosition + 2]];
                        currentPosition += 4;
                        break;
                    default:
                        break;
                }
            }

            return opcodes[0];
        }

        /// <summary>
        /// https://adventofcode.com/2019/day/2#part2
        /// </summary>
        private static int Part2(List<int> listOfIntegers)
        {
            var computer = new Intcode(listOfIntegers);

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    if (computer.Execute(noun, verb) == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            throw new Exception("Could not find noun/verb combination.");
        }
    }

    public enum Opcode
    {
        Add = 1,
        Multiply = 2,
        Halt = 99
    }

    class Intcode
    {
        private List<int> memory;
        private List<int> backup;
        private int instructionPointer = 0;
        
        public Intcode(List<int> listOfIntegers)
        {
            memory = listOfIntegers.ToList();
            backup = listOfIntegers.ToList();
        }

        public int Execute(int noun, int verb)
        {
            ResetMemory(noun, verb);

            while ((Opcode)memory[instructionPointer] != Opcode.Halt)
            {
                switch ((Opcode)memory[instructionPointer])
                {
                    case Opcode.Add:
                        memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] + memory[memory[instructionPointer + 2]];
                        instructionPointer += 4;
                        break;
                    case Opcode.Multiply:
                        memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] * memory[memory[instructionPointer + 2]];
                        instructionPointer += 4;
                        break;
                    default:
                        throw new Exception("Unknown Opcode.");
                }
            }

            return memory[0];
        }

        private void ResetMemory(int noun, int verb)
        {
            memory = backup.ToList();
            memory[1] = noun;
            memory[2] = verb;

            instructionPointer = 0;
        }
    }
}