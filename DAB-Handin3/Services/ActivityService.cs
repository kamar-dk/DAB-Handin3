using DAB_Handin3.Models;
using MongoDB.Driver;

namespace DAB_Handin3.Services
{
    public class ActivityService
    {
        DataAccess db;

        private const string ActivityCollection = "Activity";
        private IMongoCollection<Activity> Collection;

        public ActivityService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Activity>(ActivityCollection);
        }

        public void CreateActivity(Activity activity)
        {
            Collection.InsertOne(activity);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(ActivityCollection);
        }

        public void GetBookedFacilitiesBookingUserTime()
        {
            List<Activity> activities = Collection.Find(activity => true).ToList();

            foreach (var activity in activities)
            {
                Console.WriteLine($"Booking User: {activity.Citizen.Name}, Facility Name: {activity.Facility.Name}, Timeslot: from {activity.StartTime} to {activity.EndTime}");
            }
        }

        public void GetBookingsWithParticipants()
        {
            List<Activity> activities = Collection.Find(activity => true).ToList();

            foreach (var activity in activities)
            {
                Console.WriteLine($"Facility Name: {activity.Facility.Name}, Timeslot: from {activity.StartTime} to {activity.EndTime}, Paticipants");
                var temp = activity.Participants;

                foreach (var act in temp)
                {
                    Console.WriteLine(act.Cpr);
                }
            }
        }

        public void AddParticipant(Activity activity, Participant participant)
        {
            Console.WriteLine($"Acitivity ID: {activity.ActivityId}");
            activity.Participants.Add(participant);
        }
    }
}
