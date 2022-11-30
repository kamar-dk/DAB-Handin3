using DAB_Handin3.Models;
using MongoDB.Driver;

namespace DAB_Handin3.Services
{
    public class MaintenanceLogService
    {
        DataAccess db;

        private const string MaintenanceLogCollection = "MaintenanceLog";
        private IMongoCollection<MaintenanceLog> Collection;

        public MaintenanceLogService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<MaintenanceLog>(MaintenanceLogCollection);
        }

        public void CreateMaintanceLog(MaintenanceLog maintenanceLog)
        {
            Collection.InsertOne(maintenanceLog);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(MaintenanceLogCollection);
        }
    }
}
