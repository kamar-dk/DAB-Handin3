using DAB_Handin3.Models;
using DAB_Handin3.Services;

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
                    Console.WriteLine();
                    VaelgOpgave(consoleKeyInfo.KeyChar);
                }

                else
                {
                    return;
                }
            }
        }

        static void VaelgOpgave(char c)
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
                    _activity.GetBookedFacilitiesBookingUserTime();
                    break;
                case 'd':
                    _activity.GetBookingsWithParticipants();
                    break;
                case 'e':
                    _facility.GetMaintenanceHistory();
                    break;
            }
        }

        public static void SeedData()
        {
            _activity.DropCollection();
            _citizen.DropCollection();
            _facility.DropCollection();
            _maintenanceLog.DropCollection();
            _participant.DropCollection();
            _personnel.DropCollection();

            Personnel per1 = new Personnel() { Name = "Jan" };
            _personnel.CreatePersonel(per1);

            MaintenanceLog m1 = new MaintenanceLog() { Date = DateTime.Now, Description = "Slået græs", Personnel = per1 };
            _maintenanceLog.CreateMaintanceLog(m1);

            Facility f1 = new Facility()
            {
                Name = "Uni parken",
                Type = "Park",
                Latitude = 56.87,
                Longitude = 21.20,
                Decription = "Uni parken i århus",
                MaintenanceLogs = new List<MaintenanceLog>() { m1 }
            };
            Facility f2 = new Facility()
            {
                Name = "Bål plads",
                Type = "Bål Plads",
                Latitude = 57.87,
                Longitude = 22.20,
                Decription = "Bål plads i hårhus"
            };
            Facility f3 = new Facility()
            {
                Name = "Shelter plads 1",
                Type = "Shelterplads",
                Latitude = 87.29,
                Longitude = 22.22,
                Decription = "Shelter plads 1 somwhere in aarhus"
            };
            Facility f4 = new Facility()
            {
                Name = "Park 2",
                Type = "Park",
                Latitude = 57.64,
                Longitude = 21.22,
                Decription = "Park i aarhus"
            };

            _facility.CreateFacility(f1);
            _facility.CreateFacility(f2);
            _facility.CreateFacility(f3);
            _facility.CreateFacility(f4);

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

            Participant p1 = new Participant() { Cpr = "1234567890", Name = "Trine" };
            Participant p2 = new Participant() { Cpr = "9876543210", Name = "Lasse" };

            _participant.CreateParticipant(p1);
            _participant.CreateParticipant(p2);

            var a1 = new Activity()
            {
                StartTime = new DateTime(2022, 11, 11, 8, 30, 00),
                EndTime = new DateTime(2022, 12, 11, 23, 30, 00),
                Note = "Bla",
                Citizen = c1,
                Facility = f1,
                Participants = new List<Participant> { p1, p2 }
            };
            var a2 = new Activity()
            {
                StartTime = new DateTime(2022, 11, 11, 8, 30, 00),
                EndTime = new DateTime(2022, 12, 11, 23, 30, 00),
                Note = "Bla",
                Citizen = c2,
                Facility = f2,
                Participants = new List<Participant> { p2 }
            };

            _activity.CreateActivity(a1);
            _activity.CreateActivity(a2);
        }
    }
}

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

