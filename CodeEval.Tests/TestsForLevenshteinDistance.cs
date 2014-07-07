/*
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForLevenshteinDistance: CodeEvalTest
    {
        [Test]
        public void IsFriendsWith_WhenDistancesAre1_ShouldReturnTrue()
        {
            // remove 1 letter in the middle
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recuriveness"), Is.True);
            // replace 1 letter
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recurtiveness"), Is.True);
            // remove first letter
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","ecursiveness"), Is.True);
            // remove last letter
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recursivenes"), Is.True);
            // add 1 letter at the end
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recursivenesst"), Is.True);
            // add 1 letter at the beginning
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","arecursiveness"), Is.True);
            // add 1 letter in the middle
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recursivaeness"), Is.True);
        }

        [Test]
        public void IsFriendsWith_WhenWordsAreEqual_ShouldReturnFalse()
        {
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","recursiveness"), Is.False);
            Assert.That(LevenshteinDistance.AreFriends("elastic","elastic"), Is.False);
            Assert.That(LevenshteinDistance.AreFriends("macrographies","macrographies"), Is.False);
        }

        [Test]
        public void IsFriendsWith_WhenWordsAreTooDifferent_ShouldReturnFalse()
        {
            // completely different words
            Assert.That(LevenshteinDistance.AreFriends("recursiveness","elastic"), Is.False);

            // 2 letters added
            Assert.That(LevenshteinDistance.AreFriends("elastic","elasticcc"), Is.False);

            // 2 letters removed
            Assert.That(LevenshteinDistance.AreFriends("macrographies","macrograies"), Is.False);

            // 2 letters replaced
            Assert.That(LevenshteinDistance.AreFriends("macrographies","sicrographies"), Is.False);
        }

        [Test]
        public void GetSocialNetworkSize_WhenTestCaseIsElastic_ShouldReturn4()
        {
            var levenshteinDistance = new LevenshteinDistance(ReadTestFile("LevenshteinDistance.words.txt"));
            Assert.That(levenshteinDistance.GetSocialNetworkSize("elastic"), Is.EqualTo(4));
        }

        [Test]
        public void GetSocialNetworkSize_WhenTestCaseIsRecursiveness_ShouldReturn1()
        {
            var levenshteinDistance = new LevenshteinDistance(ReadTestFile("LevenshteinDistance.words.txt"));
            Assert.That(levenshteinDistance.GetSocialNetworkSize("recursiveness"), Is.EqualTo(1));
        }

        [Test]
        public void GetSocialNetworkSize_WhenTestCaseIsMacrographies_ShouldReturn1()
        {
            var levenshteinDistance = new LevenshteinDistance(ReadTestFile("LevenshteinDistance.words.txt"));
            Assert.That(levenshteinDistance.GetSocialNetworkSize("macrographies"), Is.EqualTo(1));
        }
    }
}
*/
