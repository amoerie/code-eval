using System.Collections.Generic;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForDigitStatistics
    {
        [Test]
        public void RecurringPatterns_WhenZeroToNine_ShouldHaveCorrectValues()
        {
            IDictionary<int, int[]> patterns = new DigitStatistics().RecurringPatterns;
            Assert.That(patterns[0], Is.EquivalentTo(new int[] { 0, 0, 0, 0 }));
            Assert.That(patterns[1], Is.EquivalentTo(new int[] { 1, 1, 1, 1 }));
            Assert.That(patterns[2], Is.EquivalentTo(new int[] { 2, 4, 8, 6 }));
            Assert.That(patterns[3], Is.EquivalentTo(new int[] { 3, 9, 7, 1 }));
            Assert.That(patterns[4], Is.EquivalentTo(new int[] { 4, 6, 4, 6 }));
            Assert.That(patterns[5], Is.EquivalentTo(new int[] { 5, 5, 5, 5 }));
            Assert.That(patterns[6], Is.EquivalentTo(new int[] {6, 6, 6, 6}));
            Assert.That(patterns[7], Is.EquivalentTo(new int[] {7, 9, 3, 1}));
            Assert.That(patterns[8], Is.EquivalentTo(new int[] {8, 4, 2, 6}));
            Assert.That(patterns[9], Is.EquivalentTo(new int[] {9, 1, 9, 1}));
        }

        [Test]
        public void GetStatistics_WhenAIs2AndNIs5_ShouldReturnCorrectStatistics()
        {
            var digitStatistics = new DigitStatistics();
            digitStatistics.PrintStatistics("2 5");
            var statistics = digitStatistics.GetStatistics(2, 5);
            Assert.That(statistics[0], Is.EqualTo(0));
            Assert.That(statistics[1], Is.EqualTo(0));
            Assert.That(statistics[2], Is.EqualTo(2));
            Assert.That(statistics[3], Is.EqualTo(0));
            Assert.That(statistics[4], Is.EqualTo(1));
            Assert.That(statistics[5], Is.EqualTo(0));
            Assert.That(statistics[6], Is.EqualTo(1));
            Assert.That(statistics[7], Is.EqualTo(0));
            Assert.That(statistics[8], Is.EqualTo(1));
            Assert.That(statistics[9], Is.EqualTo(0));
        }

        [Test]
        public void GetStatistics_WhenLotsOfInput_ShouldNotTimeout()
        {
            var lines = new []
            {
                "8 795785646821",
                "6 53496986243",
                "8 297524396766",
                "4 554952437444",
                "4 72278430105",
                "9 588602447427",
                "6 120457005108",
                "4 630105152457",
                "5 581650306834",
                "5 468164026551",
                "2 623143568700",
                "9 729475580731",
                "6 442371810935",
                "8 517055064797",
                "7 329829183419",
                "8 14900849866",
                "6 600641473468",
                "2 489147151488",
                "5 777970705919",
                "5 82830654563",
                "9 786478740017",
                "4 204093254367",
                "3 781280384213",
                "7 179376317632",
                "5 854213888418",
                "9 334190367961",
                "2 996915859227",
                "2 626842586445",
                "4 900488568270",
                "2 857778643269",
                "7 524390554196",
                "6 199156527724",
                "8 393869820715",
                "2 968422075409",
                "9 625022909768",
                "4 736113166785",
                "5 373784795474",
                "2 834842005900",
                "5 666510346610",
                "3 413110634798"
            };
            var digitStatistics = new DigitStatistics();
            foreach (var line in lines)
            {
                digitStatistics.PrintStatistics(line);
            }
        }
    }
}