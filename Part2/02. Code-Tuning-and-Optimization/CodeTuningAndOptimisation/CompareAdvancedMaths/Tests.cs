using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMaths
{
    public abstract class Tests
    {
        public virtual double SquareRootTest() { return 0; }

        public virtual double NaturalLogarithmTest() { return 0; }

        public virtual double SineTest() { return 0; }

        public virtual double SquareRootAltTest() { return 0; }

        public virtual double[] Results()
        {
            double[] results = new double[4];
            double totalSquareRootResults = 0;
            double totalNaturalLogarithmResults = 0;
            double totalSineResults = 0;
            double totalSquareRootAltResults = 0;

            int cycles = 20;
            for (int i = 0; i < cycles; i++)
            {
                totalSquareRootResults += this.SquareRootTest();
                totalNaturalLogarithmResults += this.NaturalLogarithmTest();
                totalSineResults += this.SineTest();
                totalSquareRootAltResults += this.SquareRootAltTest();
            }

            results[0] = totalSquareRootResults / cycles; //in ms
            results[1] = totalNaturalLogarithmResults / cycles;
            results[2] = totalSineResults / cycles;
            results[3] = totalSquareRootAltResults / cycles;

            return results;
        }
    }
}
