using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEval
{
    public class FileSize
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new FileInfo(args[0]).Length);
        }
    }
}
