using DAB_Handin3.Models;
using MongoDB.Driver;

namespace DAB_Handin3.Services
{
    public class CitizenService
    {
        DataAccess db;
        private const string CitizenCollection = "Citizen";
        private IMongoCollection<Citizen> Collection;

        public CitizenService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Citizen>(CitizenCollection);
        }

        public void CreateCitizen(Citizen citizen)
        {
            Collection.InsertOne(citizen);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(CitizenCollection);
        }
    }
}
