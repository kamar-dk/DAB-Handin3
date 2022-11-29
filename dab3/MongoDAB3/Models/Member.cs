
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models
{
    public class Member
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
    
		[BsonElement("FirstName")]
		public string FirstName { get; set; }
		[BsonElement("LastName")]
		public string LastName { get; set; }

		[BsonElement("Societies")]
		public IList<string> Societies { get; set; }
    }
}
