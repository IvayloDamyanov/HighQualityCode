using System;
using System.Diagnostics;

namespace CompareAdvancedMaths
{
    public class DecimalTests : Tests
    {
        private decimal _first;
        private decimal _destination;

        public DecimalTests(int num1)
        {
            this._first = (decimal)num1;
        }

        public override double SquareRootAltTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                this._destination = Sqrt(_first);
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public static decimal Sqrt(decimal x, decimal? guess = null)
        {
            var ourGuess = guess.GetValueOrDefault(x / 2M);
            var result = x / ourGuess;
            var average = (ourGuess + result) / 2M;

            if (average == ourGuess)
            {
                return average;
            }
            else
            {
                return Sqrt(x, average);
            }
        }
    }
}
