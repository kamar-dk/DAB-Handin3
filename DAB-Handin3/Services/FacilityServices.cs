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
        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(FacilityCollection);
        }

        public void CreateFacility(Facility facility)
        {
            Collection.InsertOne(facility);
        }

        // opgave2_1
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
        public void GetMaintenanceHistory()
        {
        
            List<Facility> facilities = Collection.Find(facility => true).ToList();

            foreach (var facility in facilities)
            {
                Console.WriteLine($"Facility Name: {facility.Name}, Maintenance:");
                var temp = facility.MaintenanceLogs;
                
                foreach (var act in temp.EmptyIfNull())
                {
                    Console.WriteLine($"Maintance Decription: {act.Description}, Done at date: {act.Date}, maintance done by {act.Personnel.Name}");
                    
                }
            }
            
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source) =>
            source != null ? source : Enumerable.Empty<T>();
    }
}
