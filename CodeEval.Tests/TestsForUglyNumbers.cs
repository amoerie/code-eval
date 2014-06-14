using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForUglyNumbers
    {
        [Test]
        public void GetNumberOfExpressions_WhenNumberIs011_NumberOfExpressionsShouldBe6()
        {
            var uglyNumbers = new UglyNumbers("011");
            int numberOfExpressions = uglyNumbers.GetNumberOfExpressions();
            Assert.That(numberOfExpressions, Is.EqualTo(6));
        }

        [Test]
        public void GetNumberOfExpressions_WhenNumberIs12345_NumberOfExpressionsShouldBe64()
        {
            var uglyNumbers = new UglyNumbers("12345");
            int numberOfExpressions = uglyNumbers.GetNumberOfExpressions();
            Assert.That(numberOfExpressions, Is.EqualTo(64));
        }

        [Test]
        public void GetNumberOfExpressions_WhenNumberIs1_NumberOfExpressionsShouldBe0()
        {
            var uglyNumbers = new UglyNumbers("1");
            int numberOfExpressions = uglyNumbers.GetNumberOfExpressions();
            Assert.That(numberOfExpressions, Is.EqualTo(0));
        }

        [Test]
        public void GetNumberOfExpressions_WhenNumberIs9_NumberOfExpressionsShouldBe1()
        {
            var uglyNumbers = new UglyNumbers("9");
            int numberOfExpressions = uglyNumbers.GetNumberOfExpressions();
            Assert.That(numberOfExpressions, Is.EqualTo(1));
        }

        [Test]
        public void GetNumberOfExpressions_WhenALotOfNumbers_ShouldNotTimeout()
        {
            string[] numbers =
            {
                "0", "886683679", "40", "13", "85", "156", "20", "011", "4147", "3128664", "1",
                "0000000000277", "9940999", "7679", "9221581623", "1433442", "24", "43620766", "44", "9"
            };
            foreach (var number in numbers)
            {
                var uglyNumbers = new UglyNumbers(number);
                Console.WriteLine(number + " = " + uglyNumbers.GetNumberOfExpressions());
            }
        }

        [Test]
        public void Evaluate_WhenExpressionIs5_ShouldReturn5()
        {
            Assert.That(UglyNumbers.Utilities.Evaluate("5"), Is.EqualTo(5));
        }

        [Test]
        public void Evaluate_WhenExpressionIs5Plus1_ShouldReturn6()
        {
            Assert.That(UglyNumbers.Utilities.Evaluate("5 + 1"), Is.EqualTo(6));
        }

        [Test]
        public void Evaluate_WhenExpressionIs5Minus1_ShouldReturn4()
        {
            Assert.That(UglyNumbers.Utilities.Evaluate("5 - 1"), Is.EqualTo(4));
        }

        [Test]
        public void Evaluate_WhenExpressionIs5Minus1Plus3_ShouldReturn7()
        {
            Assert.That(UglyNumbers.Utilities.Evaluate("5 - 1 + 3"), Is.EqualTo(7));
        }

    }
}