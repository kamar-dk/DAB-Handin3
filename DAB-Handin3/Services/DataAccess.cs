using MongoDB.Driver;

namespace DAB_Handin3.Services
{
    public class DataAccess
    {
        private const string connectionString = "mongodb://localhost:27017";
        private const string databaseName = "Handin3";

        private MongoClient client; 
        private IMongoDatabase db;

        /*public DataAccess()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

        } */
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

        public MongoClient GetClient()
        {
            return client;
        }

        public IMongoDatabase GetDatabase()
        {
            return db;
        }
    }
}
