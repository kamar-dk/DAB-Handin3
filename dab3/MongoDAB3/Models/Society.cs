using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDAB3.Models
{
    public class Society
    {
	    [BsonId]
	    [BsonRepresentation(BsonType.ObjectId)]
	    public string Id { get; set; }
	    
	    [BsonElement("CVR")]
	    public string CVR { get; set; }
	    
	    [BsonElement("Activity")]
	    public string Activity { get; set; }
        
	    [BsonElement("Address")]
	    public string Address { get; set; }
        
	    [BsonElement("Name")]
	    public string Name { get; set; }

	    [BsonElement("Municipality")]
	    public string Municipality { get; set; }
	    
	    [BsonElement("Chairman")]
	    public Chairman Chairman { get; set; }

	    [BsonElement("Members")]
	    public IList<string> Members { get; set; }

	    [BsonElement("KeyResponsible")]
	    public KeyResponsible? KeyResponsible { get; set; }

	    public void skive()
	    {
		    Console.WriteLine($"{Name} with cvr {CVR} on address {Address} with chairman " +
                $"{Chairman.FirstName} {Chairman.LastName}");
	    }
    }
}
