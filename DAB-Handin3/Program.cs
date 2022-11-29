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
    public class Program
    {
        public static DataAccess db = new DataAccess();
        public static FacilityService fs;
        static void Main(string[] args)
        {

            Console.WriteLine("Start");

            fs = new FacilityService(db);

            Console.WriteLine("\n" + "SeedData Y/n)");
            ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
            if (consoleKeyInfo2.KeyChar == 'Y')
            {
                //SeedData();
            }

            while (true)
            {
                
                Console.WriteLine("\n" + "Vis Opgave2_1(a) Opgave2_2(b), Opgave2_3(c), Opgave3_2(d), Opgave3_3(e)");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.KeyChar == 'a' || consoleKeyInfo.KeyChar == 'b' || consoleKeyInfo.KeyChar == 'c' || consoleKeyInfo.KeyChar == 'd' || consoleKeyInfo.KeyChar == 'e')
                {
                    VaelgOpgave(consoleKeyInfo.KeyChar);
                }

                else
                {
                    return;
                }
            }
        }

        static void VaelgOpgave( char c)
        {
            switch (c)
            {
                case 'a':
                    //db.GetFacilitysNameLocation();
                    fs.GetFacilitysNameLocation();
                    break;

                case 'b':
                    fs.GetFacilitysOrdered();
                    break;

                case 'c':
                    //Opgave2_3;
                    break;
                case 'd':
                    //Opgave3_2;
                    break;
                case 'e':
                    //Opgave3_3;
                    break;
            }
        }
    }
}
