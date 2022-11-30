using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class MaintenanceLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MaintenanceId { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Personnel Personnel { get; set; }
        //public Facility Facility { get; set; }
    }
}
