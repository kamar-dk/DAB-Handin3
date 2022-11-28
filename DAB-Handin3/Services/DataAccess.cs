using DAB_Handin3.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class DataAccess
    {
        private const string connectionString = "mongodb://localhost:27017";
        private const string databaseName = "Handin3";
        private const string FacilityCollection = "Facility";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<Facility>> GetAllFacilitys()
        {
            var facilityCollection = ConnectToMongo<Facility>(FacilityCollection);
            var results = await facilityCollection.FindAsync(_ => true);
            return results.ToList();
        }
    }
}
