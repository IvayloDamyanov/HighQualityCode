using Refactoring.Contracts;
using Refactoring.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    public class Matrix
    {
        private int size;
        private int[,] body;
        private int[] rowDirectionsTemplate = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private int[] columnDirectionsTemplate = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private int directionsLength;
        private ILogger logger = new Logger();

        private int count = 1;
        private int currentRow = 0;
        private int currentColumn = 0;
        private int currentRowDirection = 1;
        private int currentColumnDirection = 1;

        public Matrix(int size)
        {
            this.Size = size;
            this.Body = new int[Size, Size];
            this.directionsLength = rowDirectionsTemplate.Length;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        }

        public int[,] Body
        {
            get
            {
                return this.body;
            }
            private set
            {
                this.body = value;
            }
        }

        private bool FindEmptyCell()
        {
            currentRow = 0;
            currentColumn = 0;
            for (int r = 0; r < this.Body.GetLength(0); r++)
            {
                for (int c = 0; c < this.Body.GetLength(0); c++)
                {
                    if (this.Body[r, c] == 0)
                    {
                        currentRow = r;
                        currentColumn = c;

                        ResetCurrentDirection();
                        return true;
                    }
                }
            }
            return false;
        }

        private void ResetCurrentDirection()
        {
            currentRowDirection = 1;
            currentColumnDirection = 1;
        }

        private bool HasAnotherMove()
        {
            int[] rowDirections = new int[directionsLength];
            Array.Copy(rowDirectionsTemplate, rowDirections, directionsLength);
            int[] columnDirections = new int[directionsLength];
            Array.Copy(columnDirectionsTemplate, columnDirections, directionsLength);
            int newRow;
            int newColumn;

            for (int i = 0; i < directionsLength; i++)
            {
                newRow = currentRow + rowDirections[i];
                if (newRow < 0 || Size <= newRow)
                {
                    rowDirections[i] = 0;
                }

                newColumn = currentColumn + columnDirections[i];
                if (newColumn < 0 || Size <= newColumn)
                {
                    columnDirections[i] = 0;
                }
            }

            for (int i = 0; i < directionsLength; i++)
            {
                newRow = currentRow + rowDirections[i];
                newColumn = currentColumn + columnDirections[i];
                if (Body[newRow, newColumn] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void ChangeDirection()
        {
            int directionsIndex = 0;

            for (int i = 0; i < directionsLength; i++)
            {
                if ((rowDirectionsTemplate[i] == currentRowDirection)
                    && (columnDirectionsTemplate[i] == currentColumnDirection))
                {
                    directionsIndex = i;
                    break;
                }
            }

            if (directionsIndex == directionsLength - 1)
            {
                ResetCurrentDirection();
                return;
            }

            currentRowDirection = rowDirectionsTemplate[directionsIndex + 1];
            currentColumnDirection = columnDirectionsTemplate[directionsIndex + 1];
        }

        public void FillMatrix()
        {
            for (int i = count; i <= Size * Size; i++)
            {
                this.Body[currentRow, currentColumn] = count;
                count++;

                if (!HasAnotherMove())
                {
                    break;
                }

                while ((currentRow + currentRowDirection >= this.Size
                        || currentRow + currentRowDirection < 0
                        || currentColumn + currentColumnDirection >= this.Size
                        || currentColumn + currentColumnDirection < 0
                        || this.Body[currentRow + currentRowDirection, currentColumn + currentColumnDirection] != 0))
                {
                    ChangeDirection();
                }

                currentRow += currentRowDirection;
                currentColumn += currentColumnDirection;
            }

            if (FindEmptyCell())
            {
                FillMatrix();
            }
        }

        public void DrawMatrix()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    logger.Write(string.Format("{0,3}", this.Body[i, j]));
                }
                logger.WriteLine();
            }
        }
    }
}
