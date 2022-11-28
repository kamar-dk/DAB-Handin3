using DAB_Handin3.Models;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class DataAccess
    {
        private IMongoCollection<Facility> _facilitys;
        private const string connectionString = "mongodb://localhost:27017";
        private const string databaseName = "Handin3";
        private const string FacilityCollection = "Facility";

        public DataAccess()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _facilitys = database.GetCollection<Facility>(FacilityCollection);
            //var facility = new Facility { Name = "Uniparken", Latitude = 0000, Longitude = 0000, Decription = "Uni park", Type = "Park" };

            //_facilitys.InsertOne(facility);
        }

        /*
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }
        */

        public List<Facility> GetFacilitys()
        {
            return _facilitys.Find(facility => true).ToList();
        }

        // Opgave 2_1
        public void GetFacilitysNameLocation()
        {  
            List<Facility> facilitys = GetFacilitys();
            foreach (var facility in facilitys)
            {
                Console.WriteLine($"Name: {facility.Name}, Latitude: {facility.Latitude}, Longitude: {facility.Longitude}");
            }
        }

        // opgave2_2
        public void GetFacilitysOrdered()
        {
            List<Facility> facilities = _facilitys.Find(facility => true).ToList()
                .OrderBy(facility => facility.Type)
                .ToList();

            /*List<Facility> facilities = GetFacilitys();
            facilities.OrderBy(f => f.Type).ToList();
            */
            foreach (var facility in facilities)
            {
                Console.WriteLine($"Name: {facility.Name}, Latitude: {facility.Latitude}, Longitude: {facility.Longitude}, Type: {facility.Type}");
            }

        }


        /*public async Task<List<Facility>> GetAllFacilitys()
        {

            

            var facilityCollection = ConnectToMongo<Facility>(FacilityCollection);
            var results = await facilityCollection.FindAsync(_ => true);
            return results.ToList();
        }*/
    }
}
