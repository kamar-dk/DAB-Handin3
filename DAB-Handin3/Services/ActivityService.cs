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

        public void AddParticipant(Participant participant)
        {

            Activity activity = participant.Activity;
            activity.Participants.Add(participant);
        }
    }
}
