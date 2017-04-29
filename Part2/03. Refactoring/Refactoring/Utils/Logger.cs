using Refactoring.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Utils
{
    class Logger : ILogger
    {
        public string Write(string output = null)
        {
            Console.Write(output);
            return output;
        }

        public string WriteLine(string output = null)
        {
            Console.WriteLine(output);
            return output;
        }
    }
}
