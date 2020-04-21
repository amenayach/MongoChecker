namespace MongoChecker
{
    using System;

    public sealed class ArgumentActionRouter : IDisposable
    {
        public ArgumentActionRouter((string option, Action action)[] actionRoutes)
        {
            Extensions.Print("Please enter the number of the targeted action:");

            Console.WriteLine();

            for (int i = 0; i < actionRoutes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {actionRoutes[i].option}");
            }

            Console.WriteLine();

            var dataNumber = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(dataNumber, out int targetNumber) && actionRoutes.Length >= targetNumber)
            {
                actionRoutes[targetNumber - 1].action?.Invoke();
            }
            else
            {
                Extensions.Print("Invalid target number!");
            }

            Console.WriteLine();
            Extensions.Print("================================================", ConsoleColor.Blue);
            Console.WriteLine();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public static void Run(params (string option, Action action)[] actionRoutes)
        {
            using (new ArgumentActionRouter(actionRoutes)) { };
        }
    }
}
