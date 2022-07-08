﻿namespace AdventOfCode.Console.Core
{
    public class Calendar
    {
        public int Year { get; set; }
        public int Length { get; set; } = 25;
        public IEnumerable<Day> Days { get; set; } = new List<Day>();

        public Day this[int index] { get => FindDayByIndex(index); }

        private Day FindDayByIndex(int index)
        {
            Day? result = Days.FirstOrDefault(d => d.Index == index);
            if (result == null)
            { 
                throw new ArgumentOutOfRangeException($"Index out of range: {index}");
            }
            return result;
        }
    }
}