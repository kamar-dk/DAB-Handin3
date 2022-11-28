using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Models
{
    public class MaintenanceLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int MaintenanceId { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
