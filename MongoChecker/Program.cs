namespace MongoChecker
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            ArgumentActionRouter.Run(
                    ("Read only data", () => new TestDataReader().Execute()),
                    ("Read and write data", () => new TestDataWriter().Execute())
                );

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to exit...");
            Console.ReadLine();
        }
    }
}
