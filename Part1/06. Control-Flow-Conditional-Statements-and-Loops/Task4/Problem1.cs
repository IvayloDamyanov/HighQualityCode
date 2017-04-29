namespace Problem1
{
    using System;

    public class Problem1
    {
        public static void Main()
        {
            int userInputNumber = int.Parse(Console.ReadLine());
            int firstDigit = userInputNumber / 100;
            int secondDigit = (userInputNumber / 10) % 10;
            int thirtdDigit = userInputNumber % 10;
            double resultNumber = 0;

            if (secondDigit % 2 == 0)
            {
                resultNumber = (firstDigit + secondDigit) * thirtdDigit;
            }
            else
            {
                resultNumber = (firstDigit * secondDigit) / thirtdDigit;
            }
            
            Console.WriteLine("{0:0.00}", resultNumber);
        }
    }
}
