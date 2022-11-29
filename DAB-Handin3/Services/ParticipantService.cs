using DAB_Handin3.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class ParticipantService
    {
        DataAccess db;

        private const string ParticipantCollection = "Participant";
        private IMongoCollection<Participant> Collection;

        public ParticipantService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Participant>(ParticipantCollection);
        }
    }
}
