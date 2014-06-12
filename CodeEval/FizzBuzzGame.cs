using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEval
{
    public class FizzBuzzGame
    {
        private readonly int _firstDivisor;
        private readonly int _secondDivisor;

        public FizzBuzzGame(int firstDivisor, int secondDivisor)
        {
            _firstDivisor = firstDivisor;
            _secondDivisor = secondDivisor;
        }

        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    string[] split = line.Split(' ');
                    int firstDivisor = Convert.ToInt32(split[0]);
                    int secondDivisor = Convert.ToInt32(split[1]);
                    int limit = Convert.ToInt32(split[2]);
                    string gameResult = new FizzBuzzGame(firstDivisor, secondDivisor).Play(limit);
                    Console.WriteLine(gameResult);
                }
            }
        }

        public string Play(int limit)
        {
            return string.Join(" ", Loop().Take(limit));
        }

        private IEnumerable<string> Loop()
        {
            int currentNumber = 1;
            while (true)
            {
                if (currentNumber%_firstDivisor == 0 && currentNumber%_secondDivisor == 0)
                    yield return "FB";
                else if (currentNumber%_firstDivisor == 0)
                    yield return "F";
                else if (currentNumber%_secondDivisor == 0)
                    yield return "B";
                else
                    yield return Convert.ToString(currentNumber);
                currentNumber++;
            }
        }
    }
}