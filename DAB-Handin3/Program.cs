using DAB_Handin3.Models;
using DAB_Handin3.Services;
using MongoDB.Driver;
using System.Runtime.Intrinsics.X86;

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
        public static FacilityService _facility = new FacilityService(db);
        public static CitizenService _citizen = new CitizenService(db);
        public static ActivityService _activity = new ActivityService(db);
        public static MaintenanceLogService _maintenanceLog = new MaintenanceLogService(db);
        public static ParticipantService _participant = new ParticipantService(db);
        public static PersonnelService _personnel = new PersonnelService(db);

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            Console.WriteLine("\n" + "SeedData Y/n)");
            ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
            if (consoleKeyInfo2.KeyChar == 'Y')
            {
                SeedData();
                
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
                    _facility.GetFacilitysNameLocation();
                    break;

                case 'b':
                    _facility.GetFacilitysOrdered();
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

        public static void SeedData()
        {
            Facility f1 = new Facility() 
            { 
                Name = "Uni parken", 
                Type = "Park", 
                Latitude = 56.87, 
                Longitude = 21.20, 
                Decription = "Uni parken i århus" 
            };
            Facility f2 = new Facility()
            {
                Name = "Bål plads",
                Type = "Bål Plads",
                Latitude = 57.87,
                Longitude = 22.20,
                Decription = "Bål plads i hårhus"
            };

            _facility.CreateFacility(f1);
            _facility.CreateFacility(f2);

            Citizen c1 = new Citizen()
            {
                Name = "Kasper Martensen",
                Email = "Test@test.dk",
                Category = "Privat",
                PhoneNumber = "61616161",
            };
            Citizen c2 = new Citizen()
            {
                Name = "Rasmus",
                Email = "Test@Test2.dk",
                Category = "Privat",
                PhoneNumber = "00000000"
            };
            _citizen.CreateCitizen(c1);
            _citizen.CreateCitizen(c2);



            var a1 = new Activity()
            {
                StartTime = new DateTime(2022, 11, 11, 8, 30, 00),
                EndTime = new DateTime(2022, 12, 11, 23, 30, 00),
                Note = "Bla",
                Citizen = c1,
                Facility = f1,
            };
            var a2 = new Activity()
            {
                StartTime = new DateTime(2022, 11, 11, 8, 30, 00),
                EndTime = new DateTime(2022, 12, 11, 23, 30, 00),
                Note = "Bla",
                Citizen = c2,
                Facility = f2,
            };

            _activity.CreateActivity(a1);
            _activity.CreateActivity(a2);

            Participant p1 = new Participant() {Activity = a1, Cpr = "1234567890" };
            Participant p2 = new Participant() {Activity = a2, Cpr = "9876543210" };

            _participant.CreateParticipant(p1);
            _participant.CreateParticipant(p2);

            _activity.AddParticipant(a1, p1);
            _activity.AddParticipant(a2, p2);
        }
    }
}
