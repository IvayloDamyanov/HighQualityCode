using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareSimpleMaths
{
    public abstract class Tests
    {
        public virtual double AddTest() { return 0; }

        public virtual double SubtractTest() { return 0; }

        public virtual double IncrementTest() { return 0; }

        public virtual double MultiplyTest() { return 0; }

        public virtual double DivideTest() { return 0; }

        public virtual double[] Results()
        {
            double[] results = new double[5];
            double totalAddResults = 0;
            double totalSubtractResults = 0;
            double totalIncrementResults = 0;
            double totalMultiplyResults = 0;
            double totalDivideResults = 0;

            int cycles = 20;
            for (int i = 0; i < cycles; i++)
            {
                totalAddResults += this.AddTest();
                totalSubtractResults += this.SubtractTest();
                totalIncrementResults += this.IncrementTest();
                totalMultiplyResults += this.MultiplyTest();
                totalDivideResults += this.DivideTest();
            }

            results[0] = totalAddResults / cycles; //in ms
            results[1] = totalSubtractResults / cycles;
            results[2] = totalIncrementResults / cycles;
            results[3] = totalMultiplyResults / cycles;
            results[4] = totalDivideResults / cycles;

            return results;
        }
    }
}
