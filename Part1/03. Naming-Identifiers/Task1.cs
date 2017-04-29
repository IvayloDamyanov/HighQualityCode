namespace Task1
{
    using System;

    public class GenericClass
    {
        const int MAX_COUNT = 6;
        
        public static void Main()
        {
            GenericClass.Logger logger = new GenericClass.Logger();
            logger.PrintBoolean(true);
        }

        private class Logger
        {
            internal void PrintBoolean(bool isTrue)
            {
                string isTrueToString = isTrue.ToString();
                Console.WriteLine(isTrueToString);
            }
        }
    }
}
