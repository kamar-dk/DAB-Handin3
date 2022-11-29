using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models
{
	public class code
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("codeLocation")]
		public string codeLocation { get; set; }

		public override string ToString()
		{
			return $"Id: {Id} Codes lcation: {codeLocation}";
		}
	}
}
