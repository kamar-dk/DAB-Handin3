using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Facility
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FacilityId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Longitude")]
        public double Longitude { get; set; }
        [BsonElement("Latitude")]
        public double Latitude { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
        [BsonElement("Decription")]
        public string Decription { get; set; }
        //public List<Activity> Activities { get; set; }
        public List<MaintenanceLog> MaintenanceLogs { get; set; }

        public override string ToString()
        {
            return "Facility(" +
                "Id:" + FacilityId + "," +
                "Name: " + Name + "," +
                "Longitude: " + Longitude + "," +
                "Latitude: " + Latitude + "," +
                "Type: " + Type + "," +
                "Decitption: " + Decription +
                ")";
        }
    }
}
