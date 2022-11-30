using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Participant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParticipantId { get; set; }

        [BsonElement("Cpr")]
        public string Cpr { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }

        //public Activity Activity { get; set; }
    }
}
