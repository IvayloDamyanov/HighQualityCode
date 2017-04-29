using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Contracts
{
    interface ILogger
    {
        string Write(string output = null);
        string WriteLine(string output = null);
    }
}
