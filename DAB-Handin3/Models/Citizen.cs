using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Citizen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CitizenId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("CVR")]
        public string CVR { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        //[BsonElement("Activities")]
        //public IList<string> Activities { get; set; }
    }
}
