namespace Mongo.Data
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class MongoRepository
    {
        private MongoDatabase context;

        public MongoRepository()
        {
            var mongoClient = new MongoClient(@"mongodb://test:test@ds035280.mongolab.com:35280/mongochat");
            var mongoServer = mongoClient.GetServer();
            this.context = mongoServer.GetDatabase("mongochat");
        }

        public MongoCollection<T> GetCollection<T>(string collectionName) 
        {
            return this.context.GetCollection<T>(collectionName);
        }
    }
}
