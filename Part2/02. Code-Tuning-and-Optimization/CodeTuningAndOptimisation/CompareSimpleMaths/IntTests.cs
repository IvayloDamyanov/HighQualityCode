using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CompareSimpleMaths
{
    public class IntTests : Tests
    {
        private int _first;
        private int _second;
        private int _destination;

        public IntTests(int num1, int num2)
        {
            this._first = num1;
            this._second = num2;
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
