using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeEval.Tests
{
    public abstract class CodeEvalTest
    {
        protected IEnumerable<string> ReadTestFile(string testFile)
        {
            using (var wordsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CodeEval.Tests.TestFiles." + testFile))
            using (var streamReader = new StreamReader(wordsStream))
            {
                while (!streamReader.EndOfStream)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }
    }
}
