using System;
using System.Diagnostics;

namespace CompareAdvancedMaths
{
    public class DoubleTests : Tests
    {
        private double _first;
        private double _destination;

        public DoubleTests(int num1)
        {
            this._first = (double)num1;
        }

        public override double SquareRootTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = Math.Sqrt(this._first);
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double NaturalLogarithmTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = Math.Log(this._first);
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double SineTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = Math.Sin(_first);
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
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

        public double Sqrt(double x, double? guess = null)
        {
            var ourGuess = guess.GetValueOrDefault(x / 2D);
            var result = x / ourGuess;
            var average = (ourGuess + result) / 2D;

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
