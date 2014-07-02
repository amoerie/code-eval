using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeEval.Tests
{
    [TestFixture]
    public class TestsForStringSubstitution
    {
        [Test]
        public void String_Replace_WhenStringIsABCDEF_AndCharactersIsDEFAndXYZ_ShouldReturnABCXYZ()
        {
            var @string = new StringSubstitution.String("ABCDEF");
            var replaced = @string.Replace("DEF", "XYZ");
            Assert.That(replaced.ToString(), Is.EqualTo("ABCXYZ"));
        }

        [Test]
        public void String_Replace_WhenStringIsABCDEF_AndCharactersIsDEFAndXYZButFWasAlreadyReplaced_ShouldReturnABCDEF()
        {
            var @string = new StringSubstitution.String("ABCDEX");
            @string = @string.Replace("X", "F");
            Assert.That(@string.ToString(), Is.EqualTo("ABCDEF"));
            @string = @string.Replace("DEF", "XYZ");
            Assert.That(@string.ToString(), Is.EqualTo("ABCDEF"));
        }

        [Test]
        public void String_ReplaceSequence_WhenStringIs10011011001_AndSequenceIs0110_1001_0_10_11_ShouldReturn11100110()
        {
            var @string = new StringSubstitution.String("10011011001");
            var replaced = @string.ReplaceSequence("0110","1001","1001","0","10","11");
            Assert.That(replaced.ToString(), Is.EqualTo("11100110"));
        }
    }
}
