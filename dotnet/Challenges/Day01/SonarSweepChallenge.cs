﻿namespace AdventOfCode2021.Challenges
{
    public class SonarSweepChallenge : DailyChallenge
    {
        public SonarSweepChallenge(int day, string title) : base(title, day)
        {
        }

        private static int CountDepthIncrements(int[] depths)
        {
            int count = 0;
            int previous = depths[0];
            for (int i = 1; i < depths.Length; i++)
            {
                if (depths[i] > previous)
                {
                    count++;
                }
                previous = depths[i];
            }
            return count;
        }

        private static int[] SumDepthsByWindow(int[] depths, int windowSize)
        {
            List<int> sums = new List<int>();
            for (int step = 0; step + windowSize - 1 < depths.Length; step++)
            {
                int currentSum = 0;
                for (int i = 0; i < windowSize; i++)
                {
                    currentSum += depths[step + i];
                }
                sums.Add(currentSum);
            }

            return sums.ToArray();
        }

        public static int CountDepthIncrements(string[] depths)
        {
            int[] convertedDepths = Array.ConvertAll(depths, d => int.Parse(d));
            return CountDepthIncrements((int[])convertedDepths);
        }

        public static int CountDepthIncrements(string[] depths, int windowSize)
        {
            int[] convertedDepths = Array.ConvertAll(depths, d => int.Parse(d));
            int[] sums = SumDepthsByWindow(convertedDepths, windowSize);
            return CountDepthIncrements(sums);
        }

        public override IEnumerable<PuzzleAnswer> Run(string[] lines) => new List<PuzzleAnswer> { 
            new PuzzleAnswer(CountDepthIncrements(lines), "measurement increments"),
            new PuzzleAnswer(CountDepthIncrements(lines, 3), "windowed increments")
        };
    }
}