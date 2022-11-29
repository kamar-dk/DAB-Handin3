using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models;

public class KeyResponsible
{
	public string Id { get; set; }

	[BsonElement("Member")]
	public string? Member { get; set; }

	[BsonElement("Chairman")]
	public string? Chairman { get; set; }
	
	[BsonElement("Society")]
	public string? Society { get; set; }

	[BsonElement("HomeAddress")]
	public string HomeAddress { get; set; }
	
	[BsonElement("PhoneNumber")]
	public string PhoneNumber { get; set; }

	[BsonElement("PassportNumber")]
	public string PassportNumber { get; set; }

	[BsonElement("Location")]
	public List<string> LocationIds { get; set; }
}
