using NUnit.Framework;
using Refactoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.Tests
{
    [TestFixture]
    public class FillMatrix_Should
    {
        [Test]
        public void AssignCorrectValues_WhenCorrectSizeIsPassed()
        {
            Matrix matrix = (new Matrix(5));
            matrix.FillMatrix();
            int[,] body = {
                { 1, 13, 14, 15, 16 },
                { 12, 2, 21, 22, 17 },
                { 11, 23, 3, 20, 18 },
                { 10, 25, 24, 4, 19 },
                {9, 8, 7, 6, 5 }
            };

            Assert.AreEqual(body, matrix.Body);
        }
    }
}
