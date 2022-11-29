using System.Collections.Immutable;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDAB3.Models;

namespace MongoDAB3.Services
{
	public class LocationsService
	{

		private readonly string connectionString = "mongodb://localhost:27017";
		private readonly string Db = "MongoDAB3";
		private readonly string collection = "locations";		
		private readonly IMongoCollection<Location> _locations;
		private readonly IMongoDatabase _database;
		public LocationsService()
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(Db);
			_locations = _database.GetCollection<Location>(collection);

		}
		public List<Location> GetAllmunicipalityaddresses(
					)
		{
			return _locations.Find(Location => true).ToList();
		}
	}
}
