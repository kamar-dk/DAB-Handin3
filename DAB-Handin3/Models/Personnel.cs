using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Personnel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PersId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        //public List<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}
