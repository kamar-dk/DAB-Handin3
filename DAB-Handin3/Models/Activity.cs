using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_Handin3.Models
{
    public class Activity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ActivityId { get; set; }
        [BsonElement("Start Time")]
        public DateTime StartTime { get; set; }
        [BsonElement("End Time")]
        public DateTime EndTime { get; set; }
        [BsonElement("Note")]
        public string Note { get; set; }

        // foreign keys
        /*
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        public List<Participant> Participants { get; set; }
        */
    }
}
