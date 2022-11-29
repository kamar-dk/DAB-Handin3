using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDAB3.Models;


namespace MongoDAB3.Services
{
	public class BookingService
	{
		private readonly string connectionString = "mongodb://localhost:27017";
		private readonly string Db = "MongoDAB3";
		private readonly string collection = "bookings";
		private readonly IMongoCollection<Booking> _bookings;
		private readonly IMongoDatabase _database;
		public BookingService()
		{	var client = new MongoClient(connectionString);
			_database = client.GetDatabase(Db);
			_bookings = _database.GetCollection<Booking>(collection);
		}
		public List<Booking> GetallBookings()
        {						
				return _bookings.Find(Bookings => true).ToList();			
		}



	}
}

