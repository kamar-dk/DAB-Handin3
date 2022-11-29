using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models
{
	public class Location
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Address")]
		public string Address { get; set; }

		[BsonElement("Capacity")]
		public int Capacity { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("AccessCode")]
		public int? AccessCode { get; set; }

		//Reference
		[BsonElement("Municipality")]
		public string Municipality { get; set; }

		//Embedded
		[BsonElement("Keys")]
		public List<code> codes { get; set; }

		[BsonElement("Rooms")]
		public List<Room> Rooms { get; set; }

		/*public void WriteRoomAddresses()
		{
			Rooms.ForEach(r => Console.WriteLine($"{r.Name} at address {Address}"));
		}

		public string GetAccessInfo()
		{
			return $"{Name} has " +
				   (AccessCode == null ? "access code" : "keys")
				   + $" {AccessCode.ToString() ?? string.Join(", ", codes)}";
		}
*/
		public override string ToString()
		{
			return "Book(" +
				"Id: " + Id + "," +
				"Address: " + Address + "," +
				"codes: " + Municipality + "," +
				"Rooms: " + Rooms + "," +
				"code: " + codes + "," +
				"AccessCode: " + AccessCode + "," +
				"Name: " + Name +
				")";
		}



	}
}
