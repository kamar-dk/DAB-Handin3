using MongoDB.Bson;
using MongoDB.Driver;
using MongoDAB3.Models;
namespace MongoDAB3.Services
{
	public class MongoContextService
	{
		private readonly string connectionString = "mongodb://localhost:27017";
		private readonly string Db = "MongoDAB3";
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<Booking> _bookings;
		private readonly IMongoCollection<Location> _locations;
		private readonly IMongoCollection<Member> _members;
		private readonly IMongoCollection<Municipality> _municipalities;
		private readonly IMongoCollection<Society> _societies;
		private readonly IMongoCollection<KeyResponsible> _keyResponsible;		
		public MongoContextService()
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(Db);					
			_bookings = _database.GetCollection<Booking>("Bookings");
			_locations = _database.GetCollection<Location>("Locations");
			_members = _database.GetCollection<Member>("Members");
			_municipalities = _database.GetCollection<Municipality>("Municipalities");
			_societies = _database.GetCollection<Society>("Societies");
			_keyResponsible = _database.GetCollection<KeyResponsible>("KeyResponsible");
			 SeedData();}		
		public void SeedData()
		{		
			var Fredericia = new Municipality
			{
				Name = "Fredericia"
			};
			_municipalities.InsertOne(Fredericia);
			var Horsens = new Municipality
			{
				Name = "Horsens"
			};
			_municipalities.InsertOne(Horsens);

			var Velie = new Municipality
			{
				Name = "Velie"
			};
			_municipalities.InsertOne(Velie);
						
			var Morten = new Chairman
			{
				FirstName = "Morten",
				LastName = "Klo",
				Address = "2 red Street",
				CPR = "636558445",
				Email = "lone@lonsen.com"
			};
			var Omar = new Chairman
			{
				FirstName = "Omar",
				LastName = "knan",
				Address = "66 korsaf",
				CPR = "6958455566",
				Email = "Omar0@gamila.com"
			};
			var Sarah = new Chairman
			{
				FirstName = "Sarah",
				LastName = "Cris",
				Address = "98 mkj",
				CPR = "6365255555",
				Email = "Sarah@gamila.com"
			};
		

			var code1 = new code
			{
				codeLocation = "Mid"
			};

			var code2 = new code
			{
				codeLocation = "Syd"
			};


			var velijevej = new Room
			{
				AccessKey = 6366,
				Capacity = 100,
				Properties = "microfon,kaffemaskine",
				Name = "velijevej"
			};

			var Korskepaken = new Room
			{
				AccessKey = 669999885,
				Capacity = 200,
				Properties = "kaffemaskine",
				Name = "Korskepaken"
			};

			var sondborg = new Room
			{
				AccessKey = 46868,
				Capacity = 10,
				Properties = "kaffemaskine",
				Name = "søndborg"
			};

			var Mohamad = new Member
			{
				FirstName = "Mohamad",
				LastName = "Alkayem"
			};

			var Jesper  = new Member
			{
				FirstName = "Jesper",
				LastName = "Jesper"
			};

			var Mette = new Member
			{
				FirstName = "Mette",
				LastName = "crise"
			};

			_members.InsertOne(Jesper);
			_members.InsertOne(Mette);
			_members.InsertOne(Mohamad);			
			
			var Legoland = new Location
			{
				Name = "Legoland",
				Capacity = 100000,
				AccessCode = 69695555,							
				Municipality = velijevej.Id,
				Address = "Bilind",
				codes = new List<code> { code2 },
				Rooms = new List<Room> { Korskepaken }
			};

			var FredericiaHal = new Location
			{
				Name = "Fredericia hal",
				Capacity = 600,
				AccessCode = 63666666,				
				Municipality = Fredericia.Id,
				Address = "Hulemosevej 67",
				codes = new List<code> { code2 },
				Rooms = new List<Room> { sondborg }
			};
			var Togstation = new Location
			{
				Name = "Horsens Togstation",
				Capacity = 200,
				AccessCode = 6969555,
				Municipality = Horsens.Id,
				Address = "Togstation 22",
				codes = new List<code> { code1 },
				Rooms = new List<Room> { velijevej }
			};

			_locations.InsertMany(new List<Location> { Legoland, FredericiaHal , Togstation });
					
			var KeyResponsible1 = new KeyResponsible
			{
				Id="1",
				Member = Mohamad.Id,
				HomeAddress = "Korsk",
				PhoneNumber = "71455996",
				PassportNumber = "33666556-3323",
				LocationIds = new List<string> { Legoland.Id }
			};			
			var KeyResponsible2 = new KeyResponsible
			{
				Id="2",
				Member = Jesper.Id,
				HomeAddress = "sdaaqqq",
				PhoneNumber = "216636555",
				PassportNumber = "699965-3323",
				LocationIds = new List<string> { FredericiaHal.Id }
			};
		

			var Topdk = new Society
			{
				CVR = "66999955",
				Activity = "Reading",
				Address = "korskvej 63",
				Chairman = Morten,
				Name = "Topdk",
				Municipality = Fredericia.Id,
				Members = new List<string> { Mohamad.Id, Mette.Id },
			};

			var KonferrenceDk = new Society
			{
				CVR = "666999999",
				Activity = "Konferrence",
				Address = "sdsad 6",
				Chairman = Omar,
				Name = "Kommunist Partiet",
				Municipality = Horsens.Id,
				Members = new List<string> { Mette.Id, Jesper.Id },
				KeyResponsible = KeyResponsible2
			};

			_societies.InsertOne(KonferrenceDk);
			_societies.InsertOne(Topdk);
		
			var Booking1 = new Booking
			{
				StartTime = DateTime.Now,
				EndTime = DateTime.Now.Add(TimeSpan.FromHours(4)),
				Member = Mette.Id,
				Room = sondborg.Name,
				Location = FredericiaHal.Id
			};

			var Booking2 = new Booking
			{
				StartTime = DateTime.Now.Add(TimeSpan.FromHours(2)),
				EndTime = DateTime.Now.Add(TimeSpan.FromHours(4)),
				Society = KonferrenceDk.Id,
				Room = sondborg.Name,
				Location = Legoland.Id
			};

			var Booking3 = new Booking
			{
				StartTime = DateTime.Now.Add(TimeSpan.FromHours(7)),
				EndTime = DateTime.Now.Add(TimeSpan.FromHours(9)),
				Society = Topdk.Id,
				Location = sondborg.Id
			};
			var Booking4 = new Booking
			{
				StartTime = DateTime.Now.Add(TimeSpan.FromHours(10)),
				EndTime = DateTime.Now.Add(TimeSpan.FromHours(15)),
				Society = Topdk.Id,
				Location = Korskepaken.Id
			};
			var Booking5 = new Booking
			{
				StartTime = DateTime.Now.Add(TimeSpan.FromHours(5)),
				EndTime = DateTime.Now.Add(TimeSpan.FromHours(10)),
				Society = KonferrenceDk.Id,
				Location = Korskepaken.Id
			};

			_bookings.InsertOne(Booking1);
			_bookings.InsertOne(Booking2);
			_bookings.InsertOne(Booking3);
			_bookings.InsertOne(Booking4);
			_bookings.InsertOne(Booking5);

		}
	}



	
}
