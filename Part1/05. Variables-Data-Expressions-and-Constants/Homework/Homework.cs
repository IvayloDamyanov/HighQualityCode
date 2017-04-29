namespace Homework
{
    using System;

    public class Homework
    {
        //Task 2 (methods are placed before classes when in same element)
        public void PrintStatistics(double[] dataArray, int count)
        {
            double maxValue = 0;
            for (int i = 0; i < count; i++)
            {
                if (dataArray[i] > maxValue)
                {
                    maxValue = dataArray[i];
                }
            }

            PrintMax(maxValue);

            double minValue = 0;
            for (int i = 0; i < count; i++)
            {
                if (dataArray[i] < minValue)
                {
                    minValue = dataArray[i];
                }
            }

            PrintMin(maxValue);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += dataArray[i];
            }

            PrintAverage(sum / count);
        }

        //Task 1
        public class Size
        {
            public double width, height;

            public Size(double width, double height)
            {
                this.width = width;
                this.height = height;
            }

            public static Size GetRotatedSize(Size initialSize, double rotationAngle)
            {
                double initialWidth = initialSize.width;
                double initialHeight = initialSize.height;
                double sineByAngle = Math.Abs(Math.Cos(rotationAngle));
                double cosineByAngle = Math.Abs(Math.Cos(rotationAngle));

                double resultWidth = (initialWidth * cosineByAngle) + (initialHeight * sineByAngle);
                double resultHeight = (initialWidth * sineByAngle) + (initialHeight * cosineByAngle);

                Size rotatedSize = new Size(resultWidth, resultHeight);
                return rotatedSize;
            }
        }
    }
}
