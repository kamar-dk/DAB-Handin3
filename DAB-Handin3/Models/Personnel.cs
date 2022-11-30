﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Models
{
    public class Personnel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PersId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public List<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}
