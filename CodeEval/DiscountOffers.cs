using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeEval
{
    public class DiscountOffers
    {
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
                    var split = line.Split(';');
                    var customerNames = split[0].Split(',');
                    var productNames = split[1].Split(',');
                    var discountOffers = new DiscountOffers(customerNames, productNames);
                    Console.WriteLine("{0:#.00}",discountOffers.CalculateMaximumTotalScore());
                }
            }
        }

        private readonly string[] _customerNames;
        private readonly string[] _productNames;

        public DiscountOffers(IEnumerable<string> customers, IEnumerable<string> products)
        {
            _customerNames = customers.ToArray();
            _productNames = products.ToArray();
            _stopWatch = new Stopwatch();
        }

        private Stopwatch _stopWatch;

        private void StartTheClock(string description)
        {
            _stopWatch.Start();
            Console.WriteLine("Starting [{0}]", description);
        }

        private void StopTheClock(string description)
        {
            _stopWatch.Stop();
            Console.WriteLine("[{0}] took {1:##.000}s", description, _stopWatch.Elapsed.TotalSeconds);
        }

        private double CalculateRegretBasedTotalScore()
        {
            var customers = _customerNames.Select(c => new Customer(c)).ToList();
            var products = _productNames.Select(p => new Product(p)).ToList();
            var suitabilityScores = new List<SuitabilityScore>(
                from customer in customers 
                from product in products 
                select new SuitabilityScore(customer, product));

            // calculate suitability scores

            // calculate the average regret per score for not taking the maximum option for that customer/product
            foreach (var suitabilityScore in suitabilityScores)
            {
                var averageProductScore = suitabilityScores.Where(s => Equals(s.Product, suitabilityScore.Product)).Average(s => (double?)s.Score).GetValueOrDefault(0);
                var averageCustomerScore = suitabilityScores.Where(s => Equals(s.Customer, suitabilityScore.Customer)).Average(s => (double?)s.Score).GetValueOrDefault(0);

                var score = suitabilityScore.Score;
                suitabilityScore.AverageRegret = ((score - averageCustomerScore) + (score - averageProductScore)) * (-1);
            }

            // assign values based on average regret
            foreach (var suitabilityScore in suitabilityScores.OrderBy(s => s.AverageRegret))
            {
                // if a score is already assigned for the current product or customer, skip it
                if (suitabilityScores.Where(s => s.IsAssigned).Any(s => Equals(s.Customer, suitabilityScore.Customer) || Equals(s.Product, suitabilityScore.Product)))
                {
                    continue;
                }

                suitabilityScore.IsAssigned = true;
            }
            return suitabilityScores.Where(s => s.IsAssigned).Sum(s => (double?) s.Score).GetValueOrDefault(0);
        }

        public double CalculateMaximumTotalScore()
        {
            // calculate the regret based optimal score. We will use this as a benchmark for new results. Anything worse can immediately be discarded.
            var regretBasedTotalScore = CalculateRegretBasedTotalScore();

            var customers = _customerNames.Select(c => new Customer(c)).ToList();
            var products = _productNames.Select(p => new Product(p)).ToList();

            var suitabilityScores = new List<SuitabilityScore>(from customer in customers
                                                               from product in products
                                                               select new SuitabilityScore(customer, product))
                                                               .OrderByDescending(s => s.Score)
                                                               .ToList();
            // calculate suitability scores
            return SearchRecursively(0, suitabilityScores, Math.Min(customers.Count, products.Count), regretBasedTotalScore);
        }

        private double SearchRecursively(double totalScore, IList<SuitabilityScore> scores, int remaining, double benchmarkScore)
        {
            // if the list of scores is empty, we're done!
            if (!scores.Any())
            {
                return totalScore;
            }

            // short circuit: if we can see already that our benchmark score will not be reached, give up now.
            var maximumPotentialScore =
                scores.OrderByDescending(s => s.Score).Take(remaining).Sum(s => s.Score) +
                totalScore;
            if (maximumPotentialScore < benchmarkScore)
            {
                return totalScore;
            }


            // pop the first score, and try calculating with both assigning the score and not assigning the score
            var first = scores[0];
            var remainingScoresIfAssigned = scores.Where(s => !Equals(s.Customer, first.Customer) && !Equals(s.Product, first.Product)).ToList();
            var totalScoreIfAssigned = SearchRecursively(totalScore + first.Score, remainingScoresIfAssigned, remaining - 1, benchmarkScore);
            var totalScoreIfNotAssigned = SearchRecursively(totalScore, scores.Skip(1).ToList(), remaining, benchmarkScore);

            return Math.Max(totalScoreIfNotAssigned, totalScoreIfAssigned);
        }
    }

    public class SuitabilityScore
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public double Score { get; set; }
        public double AverageRegret { get; set; }
        public bool IsAssigned { get; set; }

        public SuitabilityScore(Customer customer, Product product)
        {
            Customer = customer;
            Product = product;
            Score = CalculateScore();
        }

        private double CalculateScore()
        {
            double suitabilityScore;

            /*
             * If the number of letters in the product's name is even 
             * then the SS is the number of vowels (a, e, i, o, u, y) in the customer's name multiplied by 1.5. 
             */
            if (Product.Name.Count(Char.IsLetter) % 2 == 0)
            {
                suitabilityScore = Customer.Name.Count(c => c.IsVowel()) * 1.5;
            }
            /*
             * If the number of letters in the product's name is odd then the SS is the number of consonants in the customer's name.    
             */
            else
            {
                suitabilityScore = Customer.Name.Count(c => c.IsConsonant());
            }
            /*
             * If the number of letters in the product's name shares any common factors (besides 1) 
             * with the number of letters in the customer's name then the SS is multiplied by 1.5. 
             */
            if (Customer.Name.Count(Char.IsLetter).HasCommonFactorsWith(Product.Name.Count(Char.IsLetter)))
            {
                suitabilityScore = suitabilityScore * 1.5;
            }
            return suitabilityScore;
        }
        
        public override string ToString()
        {
            return string.Format("Score: {0:00.00}, AverageRegret: {1:00.00}, IsAssigned: {2}, Customer: {3}, Product: {4}", Score, AverageRegret, IsAssigned, Customer, Product);
        }
    }

    public class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(Customer other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(Product other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }

    public static class ExtensionsForCharacter
    {
        private static readonly char[] LowerCaseVowels = "aeiouy".ToCharArray();
        private static readonly char[] LowerCaseConsonants = "bcdfghjklmnpqrstvwxz".ToCharArray();

        private static readonly ISet<char> Vowels = new HashSet<char>(LowerCaseVowels.Concat(LowerCaseVowels.Select(Char.ToUpperInvariant)));
        private static readonly ISet<char> Consonants = new HashSet<char>(LowerCaseConsonants.Concat(LowerCaseConsonants.Select(Char.ToUpperInvariant)));

        public static bool IsVowel(this char c)
        {
            return Vowels.Contains(c);
        }

        public static bool IsConsonant(this char c)
        {
            return Consonants.Contains(c);
        }
    }

    public static class ExtensionsForInt
    {
        public static bool HasCommonFactorsWith(this int @this, int other)
        {
            return GetCommonFactors(@this, other).Any();
        }

        public static IEnumerable<int> GetCommonFactors(this int @this, int other)
        {
            for (var i = 2; i <= Math.Min(@this, other); i++)
            {
                if (@this%i == 0 && other%i == 0)
                    yield return i;
            }
        }
    }
}
