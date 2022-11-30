using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Activity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ActivityId { get; set; }
        [BsonElement("Start Time")]
        public DateTime StartTime { get; set; }
        [BsonElement("End Time")]
        public DateTime EndTime { get; set; }
        [BsonElement("Note")]
        public string Note { get; set; }

        // foreign keys
        public Citizen Citizen { get; set; } // public int CitizenId { get; set; }
        public Facility Facility { get; set; } //public int FacilityId { get; set; }
        public List<Participant> Participants { get; set; } = null!;

    }
}
