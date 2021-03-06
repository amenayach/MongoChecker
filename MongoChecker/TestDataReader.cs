﻿namespace MongoChecker
{
    using MongoDB.Bson;
    //using MongoDB.Bson.IO;
    using MongoDB.Driver;
    using Newtonsoft.Json.Linq;
    //using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;

    public class TestDataReader : BaseCommandExecuter
    {
        public override void Execute()
        {
            try
            {
                Console.WriteLine("Please enter the connection string:");
                var connectionString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    connectionString = "mongodb://localhost:27017/coursesdb";
                }

                var mongoService = MongoService.GetService(connectionString);

                Console.WriteLine("Please enter the collection name:");
                var collectionName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(collectionName))
                {
                    collectionName = "course";
                }

                Console.WriteLine("Please enter the filter:");
                var filter = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = "{}";
                }

                var collection = mongoService.GetCollection<BsonDocument>(collectionName);

                var data = collection.Find(filter).ToList();

                Console.WriteLine($"Count: {data.Count()}");

                var jobjectList = data
                    .Select(m => Newtonsoft.Json.JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(m)))
                    .Select(m => JObject.Parse(m.ToString()));

                var jsonArray = new JArray(jobjectList);

                Console.WriteLine(jsonArray.ToString());

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
        }
    }
}
