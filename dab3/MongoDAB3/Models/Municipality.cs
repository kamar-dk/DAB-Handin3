using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models
{
    public class Municipality
    {
	    [BsonId]
	    [BsonRepresentation(BsonType.ObjectId)]
	    public string Id { get; set; }
     
	    [BsonElement("Name")]
        public string Name { get; set; }

	    public override string ToString()
	    {
		    return "Municipality: " + Name + " Id: " + Id;
	    }
    }
}
