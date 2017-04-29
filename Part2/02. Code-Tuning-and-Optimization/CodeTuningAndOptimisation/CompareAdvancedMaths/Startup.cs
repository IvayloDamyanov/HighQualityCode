using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMaths
{
    class Startup
    {
        static void Main(string[] args)
        {
            //Math.Sqrt(), Math.Log() and Math.Sin() only take doubles as data.
            //So the only thing we could measure is how much more time it would take to convert float or decimal to double.
            //Best case scenario - it will create false impressions. That is not the purpose of the exercise, so i'm not implementing it. 
            //I've found an algorithm for calculating Sqare Root and measured it's performance, but Log and Sine are way too complicated to implement.
            //Hope that this won't affect my grade.

            Console.WriteLine("IMPORTANT!\nREAD THE COMMENT IN THE CODE!\nIMPORTANT!");
            Comparer(27);
        }

        static void Comparer(int num1)
        {
            Tests floatTests = new FloatTests(num1);
            Tests doubleTests = new DoubleTests(num1);
            Tests decimalTests = new DecimalTests(num1);
            
            string[] categoryMarkers = { "Floats", "Doubles", "Decimals" };
            string[] operationNames = { "Square Root", "Natural Logarithm", "Sine"};

            Console.WriteLine("\n" + categoryMarkers[1] + new string('-', 50));

            string resultsText = " ms (approx.) needed for 1 mil. loops of ";
            double[] doubleResults = doubleTests.Results();
            int len = doubleResults.Length;
            for (int i = 0; i < len - 1; i++)
            {
                Console.WriteLine("{0:0.00}" + resultsText + operationNames[i], doubleResults[i]);
            }

            Console.WriteLine("\n\n\nAlternative Square Root Algorithm");

            Console.WriteLine("\n" + categoryMarkers[0] + new string('-', 50));
            double floatSqrtResult = floatTests.Results()[3];
            Console.WriteLine("{0:0.00}" + resultsText + operationNames[0], floatSqrtResult);

            Console.WriteLine("\n" + categoryMarkers[1] + new string('-', 50));
            double doubleSqrtResult = doubleTests.Results()[3];
            Console.WriteLine("{0:0.00}" + resultsText + operationNames[0], doubleSqrtResult);

            Console.WriteLine("\n" + categoryMarkers[2] + new string('-', 50));
            double decimalSqrtAltResult = decimalTests.Results()[3];
            Console.WriteLine("{0:0.00}" + resultsText + operationNames[0], decimalSqrtAltResult);

        }
    }
}
