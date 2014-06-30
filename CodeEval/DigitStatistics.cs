using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEval
{
    public class DigitStatistics
    {
        public static void Main(string[] args)
        {
            var digitStatistics = new DigitStatistics();
            foreach (var line in Utilities.ReadLines(args[0]))
            {
                digitStatistics.PrintStatistics(line);
            }
        }

        private readonly IDictionary<int, int[]> _recurringPatterns = new Dictionary<int, int[]>();

        public DigitStatistics()
        {
            for (int i = 0; i <= 9; i++)
            {
                _recurringPatterns[i] = Enumerable.Range(4, 4).Select(p => Utilities.ExtractLastDigit(Convert.ToInt32(Math.Pow(i, p)))).ToArray();
            }
        }

        public void PrintStatistics(string line)
        {
            var split = line.Split(' ');
            var a = Convert.ToInt32(split[0]);
            var n = Convert.ToInt64(split[1]);
            var statistics = GetStatistics(a, n);
            var frequencies = statistics.Select((frequency, index) => string.Format("{0}: {1}", index, frequency));
            Console.WriteLine(string.Join(", ", frequencies));
        }

        public IDictionary<int, int[]> RecurringPatterns
        {
            get { return _recurringPatterns; }
        }

        public long[] GetStatistics(int a, long n)
        {
            var statistics = new long[10];
            var patterns = _recurringPatterns[a];
            long remainder;
            long result = Math.DivRem(n, 4, out remainder);
            foreach (var pattern in patterns)
            {
                statistics[pattern] = result;
            }
            for (long i = 1; i <= remainder; i++)
            {
                var lastDigit = GetLastDigit(a, i);
                statistics[lastDigit]++;
            }
            return statistics;
        }

        private int GetLastDigit(int a, long n)
        {
            int patternIndex = Convert.ToInt32(n%4);
            return _recurringPatterns[a][patternIndex];
        }

        private static class Utilities
        {
            public static IEnumerable<string> ReadLines(string file)
            {
                using (var reader = File.OpenText(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (null == line)
                            continue;
                        yield return line;
                    }
                }
            }

            public static int ExtractLastDigit(int number)
            {
                if (number > -1 && number < 10)
                    return number;
                return Convert.ToInt32(Convert.ToString(Convert.ToString(number).Last()));
            }
        }
    }
}
