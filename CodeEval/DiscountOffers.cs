using System;
using System.Collections.Generic;
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
                    Console.WriteLine("{0:#.00}", discountOffers.CalculateMaximumTotalScore());
                }
            }
        }

        private readonly string[] _customerNames;
        private readonly string[] _productNames;
        private double _bestScore = 0;

        public DiscountOffers(IEnumerable<string> customers, IEnumerable<string> products)
        {
            _customerNames = customers.ToArray();
            _productNames = products.ToArray();
        }

        public double CalculateMaximumTotalScore()
        {
            var customers = _customerNames.Select(c => new Customer(c)).ToList();
            var products = _productNames.Select(p => new Product(p)).ToList();
            var suitabilityScores = new List<SuitabilityScore>(
                from customer in customers
                from product in products
                select new SuitabilityScore(customer, product));

            // calculate the regret based optimal score. We will use this as a benchmark. Anything worse can immediately be discarded.
            // calculate the average regret per score for not taking the maximum option for that customer/product
            foreach (var suitabilityScore in suitabilityScores)
            {
                var averageProductScore =
                    suitabilityScores.Where(s => Equals(s.Product, suitabilityScore.Product))
                        .Average(s => (double?) s.Score)
                        .GetValueOrDefault(0);
                var averageCustomerScore =
                    suitabilityScores.Where(s => Equals(s.Customer, suitabilityScore.Customer))
                        .Average(s => (double?) s.Score)
                        .GetValueOrDefault(0);

                var score = suitabilityScore.Score;
                suitabilityScore.AverageRegret = ( ( score - averageCustomerScore ) + ( score - averageProductScore ) )*
                                                 ( -1 );
            }

            // assign values based on average regret
            foreach (var suitabilityScore in suitabilityScores.OrderBy(s => s.AverageRegret))
            {
                // if a score is already assigned for the current product or customer, skip it
                if (
                    suitabilityScores.Where(s => s.IsAssigned)
                        .Any(
                            s =>
                                Equals(s.Customer, suitabilityScore.Customer) ||
                                Equals(s.Product, suitabilityScore.Product)))
                {
                    continue;
                }

                suitabilityScore.IsAssigned = true;
            }
            _bestScore = suitabilityScores.Where(s => s.IsAssigned).Sum(s => (double?) s.Score).GetValueOrDefault(0);
            suitabilityScores = suitabilityScores.OrderByDescending(s => s.AverageRegret).ToList();

            // calculate suitability scores
            return SearchRecursively(0, suitabilityScores);
        }

        private double SearchRecursively(double totalScore, IList<SuitabilityScore> scores)
        {
            // if the list of scores is empty, we're done!
            if (!scores.Any())
            {
                return totalScore;
            }

            // pop the first score, and try calculating with both assigning the score and not assigning the score
            var first = scores[0];

            // see what happens if we were to assign this score
            var remainingScoresIfAssigned =
                scores.Where(s => !Equals(s.Customer, first.Customer) && !Equals(s.Product, first.Product)).ToList();
            var totalScoreIfAssigned = SearchRecursively(totalScore + first.Score, remainingScoresIfAssigned);

            // see what happens if we don't assign this score
            var totalScoreIfNotAssigned = SearchRecursively(totalScore, scores.Skip(1).ToList());



            // take the best option
            return _bestScore = Math.Max(Math.Max(totalScoreIfNotAssigned, totalScoreIfAssigned), _bestScore);
        }

        /// <summary>
        ///     Represents one "link" between a customer and a product.
        ///     The property "IsAssigned" is only used to calculate the average regret.
        /// </summary>
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
                if (Product.Name.Count(Char.IsLetter)%2 == 0)
                {
                    suitabilityScore = Customer.Name.Count(Utilities.IsVowel)*1.5;
                }
                    /*
                 * If the number of letters in the product's name is odd then the SS is the number of consonants in the customer's name.    
                 */
                else
                {
                    suitabilityScore = Customer.Name.Count(Utilities.IsConsonant);
                }
                /*
                 * If the number of letters in the product's name shares any common factors (besides 1) 
                 * with the number of letters in the customer's name then the SS is multiplied by 1.5. 
                 */
                if (Utilities.HaveCommonFactors(Customer.Name.Count(Char.IsLetter), Product.Name.Count(Char.IsLetter)))
                {
                    suitabilityScore = suitabilityScore*1.5;
                }
                return suitabilityScore;
            }

            public override string ToString()
            {
                return
                    string.Format(
                        "Score: {0:00.00}, AverageRegret: {1:00.00}, IsAssigned: {2}, Customer: {3}, Product: {4}",
                        Score,
                        AverageRegret,
                        IsAssigned,
                        Customer,
                        Product);
            }

            protected bool Equals(SuitabilityScore other)
            {
                return Equals(Customer, other.Customer) && Equals(Product, other.Product) && Score.Equals(other.Score);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                return Equals((SuitabilityScore) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = ( Customer != null ? Customer.GetHashCode() : 0 );
                    hashCode = ( hashCode*397 ) ^ ( Product != null ? Product.GetHashCode() : 0 );
                    hashCode = ( hashCode*397 ) ^ Score.GetHashCode();
                    return hashCode;
                }
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
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                return Equals((Customer) obj);
            }

            public override int GetHashCode()
            {
                return ( Name != null ? Name.GetHashCode() : 0 );
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
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                return Equals((Product) obj);
            }

            public override int GetHashCode()
            {
                return ( Name != null ? Name.GetHashCode() : 0 );
            }
        }

        public static class Utilities
        {
            private static readonly char[] LowerCaseVowels = "aeiouy".ToCharArray();
            private static readonly char[] LowerCaseConsonants = "bcdfghjklmnpqrstvwxz".ToCharArray();

            private static readonly ISet<char> Vowels =
                new HashSet<char>(LowerCaseVowels.Concat(LowerCaseVowels.Select(Char.ToUpperInvariant)));

            private static readonly ISet<char> Consonants =
                new HashSet<char>(LowerCaseConsonants.Concat(LowerCaseConsonants.Select(Char.ToUpperInvariant)));

            public static bool IsVowel(char c)
            {
                return Vowels.Contains(c);
            }

            public static bool IsConsonant(char c)
            {
                return Consonants.Contains(c);
            }

            public static bool HaveCommonFactors(int @this, int other)
            {
                return GetCommonFactors(@this, other).Any();
            }

            public static IEnumerable<int> GetCommonFactors(int @this, int other)
            {
                for (var i = 2; i <= Math.Min(@this, other); i++)
                {
                    if (@this%i == 0 && other%i == 0)
                        yield return i;
                }
            }
        }
    }
}
