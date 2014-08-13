using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval
{
    public class TextDollar
    {
        public static void Main(string[] args)
        {
            var textDollar = new TextDollar();
            foreach (var line in Utilities.ReadLines(args[0]))
            {
                Console.WriteLine(textDollar.Print(Convert.ToInt64(line)));
            }
        }

        private readonly IDictionary<long, string> _units = new Dictionary<long, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" },
            { 4, "Four" },
            { 5, "Five" },
            { 6, "Six" },
            { 7, "Seven" },
            { 8, "Eight" },
            { 9, "Nine" },
            { 10, "Ten" },
            { 11, "Eleven" },
            { 12, "Twelve" },
            { 13, "Thirteen" },
            { 14, "Fourteen" },
            { 15, "Fifteen" },
            { 16, "Sixteen" },
            { 17, "Seventeen" },
            { 18, "Eighteen" },
            { 19, "Nineteen" },
        };

        private readonly IDictionary<long, string> _tens = new Dictionary<long, string>
        {
            { 10, "Ten" },
            { 20, "Twenty" },
            { 30, "Thirty" },
            { 40, "Forty" },
            { 50, "Fifty" },
            { 60, "Sixty" },
            { 70, "Seventy" },
            { 80, "Eighty" },
            { 90, "Ninety" },
        };

        private readonly IDictionary<long, string> _powers = new Dictionary<long, string>
        {
            { 100, "Hundred" },
            { 1000, "Thousand" },
            { 1000000, "Million" },
        };

        public string Print(long amount)
        {
            return NumberToString(amount) + "Dollars";
        }

        private string NumberToString(long number)
        {
            if (number < 1)
                return string.Empty;
            if (number < 20)
                return _units[number];
            if (number < 100)
            {
                long remainder = number % 10;
                return _tens[number - remainder] + NumberToString(remainder);
            }
            if (number < 1000)
            {
                long remainder = number % 100;
                long size = number / 100;
                return NumberToString(size) + _powers[100] + NumberToString(remainder);
            }
            if (number < 1000000)
            {
                long remainder = number % 1000;
                long size = number / 1000;
                return NumberToString(size) + _powers[1000] + NumberToString(remainder);
            }
            else
            {
                long remainder = number % 1000000;
                long size = number / 1000000;
                return NumberToString(size) + _powers[1000000] + NumberToString(remainder);
            }
        }

        public static class Utilities
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
        }
    }
}
