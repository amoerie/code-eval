using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForFizzBuzzGame
    {
        [Test, Timeout(10000)]
        public void Play_WhenFirstIs3AndSecondIs5AndLimitIs10_ShouldBe12F4BF78FB()
        {
            var fizzBuzzGame = new FizzBuzzGame(3, 5);
            var result = fizzBuzzGame.Play(10);
            Assert.That(result, Is.EqualTo("1 2 F 4 B F 7 8 F B"));
        }

        [Test, Timeout(10000)]
        public void Play_WhenFirstIs2AndSecondIs7AndLimitIs15_ShouldBe1F3F5FBF9F11F13FB15()
        {
            var fizzBuzzGame = new FizzBuzzGame(2, 7);
            var result = fizzBuzzGame.Play(15);
            Assert.That(result, Is.EqualTo("1 F 3 F 5 F B F 9 F 11 F 13 FB 15"));
        }
    }
}
