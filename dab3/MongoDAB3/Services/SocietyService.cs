using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDAB3.Models;

namespace MongoDAB3.Services
{
    public class SocietyService
    {
		private readonly string connectionString = "mongodb://localhost:27017";
		private readonly string Db = "MongoDAB3";
		private readonly string collection = "societies";
		private readonly IMongoCollection<Society> _societies;
		private readonly IMongoDatabase _database;
		public SocietyService()
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(Db);
			_societies = _database.GetCollection<Society>(collection);
		}

		public void GetAllsocieties(string activity)
		{
			Console.WriteLine("\nGet all societies (cvr, addresses and chairmen) by their activity..\n");

			var societyFilter = Builders<Society>.Filter.Eq("Activity", activity);
			var societies = _societies.Find(societyFilter).ToList();

			if (societies == null)
			{
				Console.WriteLine($"Municipality {societies} not found");
				return;
			}

			societies.ForEach(l => l.skive());
		}
	}
}

