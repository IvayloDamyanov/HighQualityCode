using System;
using System.Collections.Generic;
using CompareSimpleMaths;
using System.Linq;

namespace CompareSimpleMaths
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculating, might take a minute, please stand by!\nRun multiple times, first read does not give accurate results, due to Visual studio caching in system(i guess).");
            Comparer(12, 6);
        }

        static void Comparer(int num1, int num2)
        {
            Tests intTests = new IntTests(num1, num2);
            Tests longTests = new LongTests(num1, num2);
            Tests floatTests = new FloatTests(num1, num2);
            Tests doubleTests = new DoubleTests(num1, num2);
            Tests decimalTests = new DecimalTests(num1, num2);

            double[][] results = new double[5][];
            results[0] = intTests.Results();
            results[1] = longTests.Results();
            results[2] = floatTests.Results();
            results[3] = doubleTests.Results();
            results[4] = decimalTests.Results();

            string[] categoryMarkers = { "Ints", "Longs", "Floats", "Doubles", "Decimals" };
            string[] operationNames = { "adding", "subtracting", "incrementing", "multiplying", "dividing" };

            int len = results.Length;
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("\n" + categoryMarkers[i] + new string('-', 50));

                int len2 = results[i].Length;
                for (int j = 0; j < len2; j++)
                {
                    Console.WriteLine("{0:0.00} ms (approx.) needed for 1 mil. loops of " + operationNames[j], results[i][j]);
                }
            }
        }
    }
}
