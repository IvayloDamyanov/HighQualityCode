namespace Problem4
{
    using System;

    class Problem4
    {
        static void Main()
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());
            int[] inputIntegers = new int[numberOfIntegers];
            for (int i = 0; i < numberOfIntegers; i++)
            {
                inputIntegers[i] = int.Parse(Console.ReadLine());
            }

            int[] mergedNumbers = new int[numberOfIntegers - 1];
            for (int i = 0; i < numberOfIntegers - 1; i++)
            {
                firstInteger = (inputIntegers[i] % 10)*10;
                secondInteger = inputIntegers[i+1]/10;
                mergedNumbers[i] = firstInteger + secondInteger;
            }

            Console.WriteLine(string.Join(" ", mergedNumbers));

            int[] summedNumbers = new int[numberOfIntegers - 1];
            for (int i = 0; i < numberOfIntegers - 1; i++)
            {
                summedNumbers[i] = inputIntegers[i] + inputIntegers[i + 1];
            }

            Console.WriteLine(string.Join(" ", summedNumbers));
        }
    }
}
