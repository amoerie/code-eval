using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForTextDollar
    {
        private TextDollar _textDollar;

        [SetUp]
        public void Setup()
        {
            _textDollar = new TextDollar();
        }

        [Test]
        public void TestCases()
        {
            Assert.That(_textDollar.Print(3), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(10), Is.EqualTo("TenDollars"));
            Assert.That(_textDollar.Print(21), Is.EqualTo("TwentyOneDollars"));
            Assert.That(_textDollar.Print(466), Is.EqualTo("FourHundredSixtySixDollars"));
            Assert.That(_textDollar.Print(1234), Is.EqualTo("OneThousandTwoHundredThirtyFourDollars"));
            Assert.That(_textDollar.Print(101), Is.EqualTo("OneHundredOneDollars"));
            Assert.That(_textDollar.Print(987654321), Is.EqualTo("NineHundredEightySevenMillionSixHundredFiftyFourThousandThreeHundredTwentyOneDollars"));
        }

        [Test]
        public void HardTestCases()
        {
            Assert.That(_textDollar.Print(128), Is.EqualTo("OneHundredTwentyEightDollars"));
            Assert.That(_textDollar.Print(645), Is.EqualTo("SixHundredFortyFiveDollars"));
            Assert.That(_textDollar.Print(457), Is.EqualTo("FourHundredFiftySevenDollars"));
            Assert.That(_textDollar.Print(534067757), Is.EqualTo("FiveHundredThirtyFourMillionSixtySevenThousandSevenHundredFiftySevenDollars"));
            Assert.That(_textDollar.Print(968298504), Is.EqualTo("NineHundredSixtyEightMillionTwoHundredNinetyEightThousandFiveHundredFourDollars"));
            Assert.That(_textDollar.Print(109), Is.EqualTo("OneHundredNineDollars"));
            Assert.That(_textDollar.Print(34369), Is.EqualTo("ThirtyFourThousandThreeHundredSixtyNineDollars"));
            Assert.That(_textDollar.Print(327), Is.EqualTo("ThreeHundredTwentySevenDollars"));
            /*Assert.That(_textDollar.Print(252), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(123456789), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(92065), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(68), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(425), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(81), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(34590), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(654158870), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(24537), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(738091870), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(920325638), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(992947960), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(748208772), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(96108), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(402), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(1), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(75969), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(509), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(312056224), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(627), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(396), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(46601), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(16591), Is.EqualTo("ThreeDollars"));*/
            Assert.That(_textDollar.Print(100000000), Is.EqualTo("OneHundredMillionDollars"));
            /*Assert.That(_textDollar.Print(786), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(303483690), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(620140812), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(875), Is.EqualTo("ThreeDollars"));*/
            Assert.That(_textDollar.Print(99080), Is.EqualTo("NinetyNineThousandEightyDollars"));
            /*Assert.That(_textDollar.Print(561), Is.EqualTo("ThreeDollars"));
            Assert.That(_textDollar.Print(413), Is.EqualTo("ThreeDollars"));*/
        }
    }
}
