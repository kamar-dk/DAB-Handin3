using DAB_Handin3.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class FacilityService
    {
        DataAccess db;

        private const string FacilityCollection = "Facility";
        private IMongoCollection<Facility> Collection;

        public FacilityService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Facility>(FacilityCollection);
        }

        public void GetFacilitysNameLocation()
        {   
            List<Facility> facilities = Collection.Find(facility => true).ToList();
            foreach (var facility in facilities)
            {
                Console.WriteLine($"Name: {facility.Name}, Latitude: {facility.Latitude}, Longitude: {facility.Longitude}");
            }
        }

        // opgave2_2
        public void GetFacilitysOrdered()
        {
            List<Facility> facilities = Collection.Find(facility => true).ToList()
                .OrderBy(facility => facility.Type)
                .ToList();


            foreach (var facility in facilities)
            {
                Console.WriteLine($"Name: {facility.Name}, Latitude: {facility.Latitude}, Longitude: {facility.Longitude}, Type: {facility.Type}");
            }

        }
    }
}
