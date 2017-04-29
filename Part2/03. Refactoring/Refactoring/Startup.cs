using System;
using Refactoring;
using Refactoring.Contracts;
using Refactoring.Utils;
using Refactoring.Contracts;

namespace Refactoring
{
    class Startup
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            ILogger logger = new Logger();
            logger.WriteLine("Please input a matrix size between 1 and 100");
            string input = reader.ReadLine();
            int size;
            bool isParsed = int.TryParse(input, out size);
            while (!isParsed)
            {
                logger.WriteLine("Input must be a number");
                input = reader.ReadLine();
                isParsed = int.TryParse(input, out size);
            }

            Matrix matrix = new Matrix(size);

            matrix.FillMatrix();

            matrix.DrawMatrix();
        }
    }
}
