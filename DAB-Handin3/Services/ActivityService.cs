using DAB_Handin3.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class ActivityService
    {
        DataAccess db;

        private const string ActivityCollection = "Acticity";
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

        public void AddParticipant(Activity activity,Participant participant)
        {
            
            Console.WriteLine($"Acitivity ID: {activity.ActivityId}");
            activity.Participants.Add(participant);
        }
    }
}
