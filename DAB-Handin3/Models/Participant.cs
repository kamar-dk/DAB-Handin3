using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Models
{
    public class Participant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParticipantId { get; set; }

        [BsonElement("Cpr")]
        public string Cpr { get; set; }

        public Activity Activity { get; set; }
    }
}
