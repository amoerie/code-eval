using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEval
{
    public class UglyNumbers
    {
        public static void Main(string[] args)
        {
            foreach (var line in Utilities.ReadLines(args[0]))
            {
                var uglyNumbers = new UglyNumbers(line);
                Console.WriteLine(uglyNumbers.GetNumberOfExpressions());
            }
        }
        
        private readonly string _number;

        public UglyNumbers(string number)
        {
            while (number.StartsWith("00"))
            {
                number = number.Substring(1);
            }
            _number = number;
        }

        public int GetNumberOfExpressions()
        {
            var expressions = GenerateExpressions(string.Empty, _number).ToList();
            var evaluatedExpressions = expressions.Select(Utilities.Evaluate).ToList();
            return evaluatedExpressions.Count(Utilities.IsUglyNumber);
        }

        private IEnumerable<string> GenerateExpressions(string expression, string number)
        {
            // if number is empty, there is nothing left to evaluate
            if (string.IsNullOrEmpty(number))
            {
                yield return expression;
                yield break;
            }
            foreach (var e in ChooseNothing(expression, number))
            {
                yield return e;
            }
            if (!string.IsNullOrEmpty(expression))
            {
                foreach (var e in ChoosePlusSign(expression, number))
                {
                    yield return e;
                }
            
                foreach (var e in ChooseMinusSign(expression, number))
                {
                    yield return e;
                }
            }
        }

        private IEnumerable<string> ChooseNothing(string expression, string number)
        {
            var first = Convert.ToInt32(Convert.ToString(number.First()));
            return GenerateExpressions(expression + first, number.Substring(1));
        }

        private IEnumerable<string> ChoosePlusSign(string expression, string number)
        {
            var first = Convert.ToInt32(Convert.ToString(number.First()));
            return GenerateExpressions(expression + " + " + first, number.Substring(1));
        }

        private IEnumerable<string> ChooseMinusSign(string expression, string number)
        {
            var first = Convert.ToInt32(Convert.ToString(number.First()));
            return GenerateExpressions(expression + " - " + first, number.Substring(1));
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


            private static readonly int[] OneDigitPrimes = {2,3,5,7};
            private static readonly ConcurrentDictionary<long, bool> UglyNumbersCache = new ConcurrentDictionary<long, bool>();

            public static bool IsUglyNumber(long number)
            {
                return UglyNumbersCache.GetOrAdd(number, n => OneDigitPrimes.Any(prime => n%prime == 0));
            }

            private static readonly ConcurrentDictionary<string, long> EvaluationCache = new ConcurrentDictionary<string, long>();
            private static readonly char[] Operators = {'+', '-'};

            public static long Evaluate(string expression)
            {
                return EvaluationCache.GetOrAdd(expression, e => EvaluateInternal(new Queue<Func<long, long>>(), expression));
            }

            private static long EvaluateInternal(Queue<Func<long, long>> operations, string expression)
            {
                if (string.IsNullOrEmpty(expression))
                {
                    return Execute(operations);
                }
                expression = expression.Replace(" ", "");

                // expression starts with '+' or '-'
                if (Operators.Any(o => expression.FirstOrDefault() == o))
                {
                    var @operator = expression.Take(1).SingleOrDefault();
                    var numberAsString = new string(expression.Skip(1).TakeWhile(c => !Operators.Contains(c)).ToArray());
                    var number = Convert.ToInt64(numberAsString);
                    var remaining = expression.Substring(1 + numberAsString.Length);
                    switch (@operator)
                    {
                        case '+':
                            operations.Enqueue(n => n + number);
                            return EvaluateInternal(operations, remaining);
                        case '-':
                            operations.Enqueue(n => n - number);
                            return EvaluateInternal(operations, remaining);
                        default:
                            throw new ArgumentException("Operator '" + @operator + "' not recognized!");
                    }
                }
                // expression is a simple number
                else
                {
                    var numberAsString = new string(expression.TakeWhile(c => !Operators.Contains(c)).ToArray());
                    var number = Convert.ToInt64(numberAsString);
                    var remaining = expression.Substring(numberAsString.Length);
                    operations.Enqueue(n => number);
                    return EvaluateInternal(operations, remaining);
                }
            }

            private static long Execute(Queue<Func<long, long>> operations)
            {
                long value = 0;
                while (operations.Any())
                {
                    var operation = operations.Dequeue();
                    value = operation(value);
                }
                return value;
            }

        }
    }


}
