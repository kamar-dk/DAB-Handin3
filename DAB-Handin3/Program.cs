using DAB_Handin3.Models;
using DAB_Handin3.Services;
using MongoDB.Driver;

/*
string connectionString = "mongodb://localhost:27017";
string databaseName = "Handin3";
string collectionName = "Facility";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<Facility>(collectionName);

var facility = new Facility { Name = "Uniparken", Latitude = 0000, Longitude = 0000, Decription = "Uni park", Type = "Park" };

await collection.InsertOneAsync(facility);

var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())
{
    Console.WriteLine($"{result.FacilityId}");
}
*/


namespace DAB_Handin3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess db = new DataAccess();

            //var results = db.GetAllFacilitys();
            db.GetFacilitys().ForEach(Console.WriteLine);
            /*foreach (var result in results)
            {
                Console.WriteLine($"{result.FacilityId}");
            }*/
        }
    }
}
