using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEval
{
    public class LevenshteinDistance
    {
        private const string EndOfInput = "END OF INPUT";

        public static void Main(string[] args)
        {
            var inputLines = Utilities.ReadLines(args[0]).ToList();
            var testcases = inputLines.TakeWhile(line => !string.Equals(line, EndOfInput));
            var words = inputLines.SkipWhile(line => !string.Equals(line, EndOfInput));
            var levenshteinDistance = new LevenshteinDistance(words);
            foreach (var testcase in testcases)
            {
                Console.WriteLine(levenshteinDistance.GetSocialNetworkSize(testcase));
            }
        }

        private readonly ISet<string> _words;

        public LevenshteinDistance(IEnumerable<string> words)
        {
            _words = new HashSet<string>(words);
        }

        public int GetSocialNetworkSize(string testcase)
        {
            return GetSocialNetworkSizeInternal(testcase, new HashSet<string>());
        }

        private int GetSocialNetworkSizeInternal(string testcase, ISet<string> socialNetwork)
        {
            socialNetwork.Add(testcase);
            foreach (var word in _words)
            {
                if (AreFriends(word, testcase) && !socialNetwork.Contains(word))
                {
                    GetSocialNetworkSizeInternal(word, socialNetwork);
                }
            }
            return socialNetwork.Count;
            
        }

/*
        private static readonly IDictionary<string, bool> FriendsCache = new Dictionary<string, bool>();
*/
        public static bool AreFriends(string firstWord, string secondWord)
        {
/*            var key = string.Join(",", new[] { firstWord, secondWord }.OrderBy(s => s));
            bool areFriends;
            if (FriendsCache.TryGetValue(key, out areFriends))
            {
                return areFriends;
            }
            areFriends = AreFriendsInternal(firstWord, secondWord);
            FriendsCache[key] = areFriends;
            return areFriends;*/
            return AreFriendsInternal(firstWord, secondWord);
        }

        private static bool AreFriendsInternal(string firstWord, string secondWord)
        {
            // short-circuit for equal words, equal words are not friends
            if (string.Equals(firstWord, secondWord))
                return false;

            // if the difference in length exceeds 1, they cannot be friends
            if (Math.Abs(firstWord.Length - secondWord.Length) > 1)
                return false;

            // the empty string is friends with every 1 - letter word
            if ((firstWord.Length == 0 && secondWord.Length == 1) ||
                (firstWord.Length == 1 && secondWord.Length == 0))
                return true;

            // every 1 letter word is friends with every other 1 letter word, equality has already been tested
            if (firstWord.Length == 1 && secondWord.Length == 1)
                return true;

            /*
             * if the first characters are equal, remove them from both words and make a recursive call
             * For example:             are "recursiveness" and "recursivenes" friends?
             * is the same as asking:   are "ecursiveness"  and "ecursivenes" friends?
             */
            if (firstWord[0] == secondWord[0])
            {
                return AreFriends(firstWord.Substring(1), secondWord.Substring(1));
            }
            /*
             * if last characters are equal, remove them from both words and make a recursive call
             * For example:             are "recursiveness" and "rocursiveness" friends?
             * is the same as asking:   are "recursivenes"  and "rocursivenes" friends?
             */
            if (firstWord[firstWord.Length - 1] == secondWord[secondWord.Length - 1])
            {
                return AreFriends(firstWord.Substring(0, firstWord.Length - 1), secondWord.Substring(0, secondWord.Length - 1));
            }

            /*
             * Both the first letter and the last letter are not equal, so they cannot be friends
             */
            return false;
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
        }

    }
}
