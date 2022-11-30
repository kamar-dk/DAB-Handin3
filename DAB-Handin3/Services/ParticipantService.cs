using DAB_Handin3.Models;
using MongoDB.Driver;

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

        public void CreateParticipant(Participant participant)
        {
            Collection.InsertOne(participant);
        }
        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(ParticipantCollection);
        }
    }
}
