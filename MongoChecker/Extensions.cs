namespace MongoChecker
{
    using System;

    public class Extensions
    {
        public static void Print(string message, ConsoleColor color = ConsoleColor.Green)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
