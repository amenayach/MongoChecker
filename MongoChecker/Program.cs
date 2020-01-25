﻿namespace MongoChecker
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the connection string:");
                var mongoService = MongoService.GetService(Console.ReadLine());

                var testCollection = mongoService.GetCollection<BsonDocument>("testcol");

                testCollection.InsertOne(BsonDocument.Parse($@"{{""_id"": ""{Guid.NewGuid().ToString()}"", ""name"": ""Test name""}}"));

                var data = testCollection.Find(Builders<BsonDocument>.Filter.Empty).ToList();

                Console.WriteLine(data.First());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to exit...");
            Console.ReadLine();
        }
    }
}
