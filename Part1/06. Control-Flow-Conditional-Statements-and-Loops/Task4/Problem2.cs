namespace Problem2
{
    using System;

    class Problem2
    {
        static void Main()
        {
            string userInputSteps = Console.ReadLine();
            char[] steps = new char[userInputSteps.Length];
            for (int i = 0; i < userInputSteps.Length; i++)
            {
                steps[i] = userInputSteps[i]; 
            }

            int position = 0;
            while (position < 100)
            {
                if (position < 0 || (steps.Length - 1) < position)
                {
                    Console.WriteLine("Djor and Djano are lost at {0}!", position);
                    break;
                }
                else if (steps[position] == '^')
                {
                    Console.WriteLine("Djor and Djano are at the party at {0}!", position);
                    break;
                }
                else if (64 < steps[position] && steps[position] < 91)
                {
                    position -= (steps[position] - 64);
                }
                else if (96 < steps[position] && steps[position] < 123)
                {
                    position += (steps[position] - 96);
                }
                else
                {
                    Console.WriteLine("Invalid character");
                    break;
                }
            }
        }
    }
}
