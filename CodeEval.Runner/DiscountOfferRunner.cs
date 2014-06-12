using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeEval.Runner
{
    public static class DiscountOfferRunner
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamReader reader = File.OpenText(args[0]))
            {
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    var split = line.Split(';');
                    var customerNames = split[0].Split(',');
                    var productNames = split[1].Split(',');
                    var discountOffers = new DiscountOffers(customerNames, productNames);
                    Console.WriteLine("{0:#.00}", discountOffers.CalculateMaximumTotalScore());
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed: {0:###.00}", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        }
    }
}
