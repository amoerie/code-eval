using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace CodeEval.Runner
{
    public static class DiscountOfferRunner
    {
        public static void Main(string[] args)
        {
            var log = LogManager.GetCurrentClassLogger();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            const string line = "Aaron Adelson,Jeffery Lebowski,Samir Nagheenanajar,Michael Bolton,Justin Van Winkle,Jack Abraham,Mahmoud Abdelkader,Jareau Wade,Rob Eroh,Gabriel Sinkin,Walter Sobchak,John Evans;Dom Perignon 2000 Vintage,Girl Scouts Thin Mints,Printer paper,Three Wolf One Moon T-shirt,Widescreen Monitor - 30-inch,Batman No. 1,Vibe Magazine Subscriptions - 40 pack,iPad 2 - 4-pack,Red Swingline Stapler,16lb Bowling ball,Elephant food - 1024 lbs,Colt M1911A1,Football - Official Size,Bass Amplifying Headphones,Nerf Crossbow";
            // do something with line
            var split = line.Split(';');
            var customerNames = split[0].Split(',');
            var productNames = split[1].Split(',');
            var discountOffers = new DiscountOffers(customerNames, productNames);
            log.Debug("{0:#.00}", discountOffers.CalculateMaximumTotalScore());
        }
    }
}
