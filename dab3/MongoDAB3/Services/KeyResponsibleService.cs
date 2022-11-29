using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDAB3.Models;
namespace MongoDAB3.Services{
    public class KeyResponsibleService
    {
		private readonly string connectionString = "mongodb://localhost:27017";
		private readonly string Db = "MongoDAB3";
		private readonly string collection = "KeyResponsibles";
		private readonly IMongoCollection<KeyResponsible> _KeyResponsible;
		private readonly IMongoDatabase _database;



		public KeyResponsibleService()
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(Db);
			_KeyResponsible = _database.GetCollection<KeyResponsible>("KeyResponsibles");		
		}

		public KeyResponsible Get(string id)
		{
			return _KeyResponsible.Find<KeyResponsible>(KeyResponsible => KeyResponsible.Id == id).FirstOrDefault();
		}



	}
}

