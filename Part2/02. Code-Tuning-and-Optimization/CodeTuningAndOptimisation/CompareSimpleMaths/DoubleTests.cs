using System;
using System.Diagnostics;

namespace CompareSimpleMaths
{
    public class DoubleTests : Tests
    {
        private double _first;
        private double _second;
        private double _destination;

        public DoubleTests(int num1, int num2)
        {
            this._first = (double)num1;
            this._second = (double)num2;
        }

        public override double AddTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = this._first + this._second;
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double SubtractTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = this._first - this._second;
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double IncrementTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination++;
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double MultiplyTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = this._first * this._second;
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public override double DivideTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                this._destination = this._first / this._second;
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
