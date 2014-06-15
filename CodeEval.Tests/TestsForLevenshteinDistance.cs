using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForLevenshteinDistance
    {
        [Test]
        public void AreFriends_WhenDistancesAre1_ShouldReturnTrue()
        {
            var levenshteinDistanceCalculator = new LevenshteinDistanceCalculator();

            // remove 1 letter in the middle
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recuriveness"), Is.True);
            // replace 1 letter
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recurtiveness"), Is.True);
            // remove first letter
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "ecursiveness"), Is.True);
            // remove last letter
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recursivenes"), Is.True);
            // add 1 letter at the end
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recursivenesst"), Is.True);
            // add 1 letter at the beginning
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "arecursiveness"), Is.True);
            // add 1 letter in the middle
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recursivaeness"), Is.True);
        }

        [Test]
        public void AreFriends_WhenWordsAreEqual_ShouldReturnFalse()
        {
            var levenshteinDistanceCalculator = new LevenshteinDistanceCalculator();

            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "recursiveness"), Is.False);
            Assert.That(levenshteinDistanceCalculator.AreFriends("elastic", "elastic"), Is.False);
            Assert.That(levenshteinDistanceCalculator.AreFriends("macrographies", "macrographies"), Is.False);
        }

        [Test]
        public void AreFriends_WhenWordsAreTooDifferent_ShouldReturnFalse()
        {
            var levenshteinDistanceCalculator = new LevenshteinDistanceCalculator();

            // completely different words
            Assert.That(levenshteinDistanceCalculator.AreFriends("recursiveness", "elastic"), Is.False);

            // 2 letters added
            Assert.That(levenshteinDistanceCalculator.AreFriends("elastic", "elasticcc"), Is.False);

            // 2 letters removed
            Assert.That(levenshteinDistanceCalculator.AreFriends("macrographies", "macrograies"), Is.False);

            // 2 letters replaced
            Assert.That(levenshteinDistanceCalculator.AreFriends("macrographies", "sicrographies"), Is.False);
        }
    }
}
