using System;
using System.Diagnostics;

namespace CompareAdvancedMaths
{
    public class FloatTests : Tests
    {
        private float _first;
        private float _destination;

        public FloatTests(int num1)
        {
            this._first = (float)num1;
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

        public static float Sqrt(float x, float? guess = null)
        {
            var ourGuess = guess.GetValueOrDefault(x / 2F);
            var result = x / ourGuess;
            var average = (ourGuess + result) / 2F;

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
