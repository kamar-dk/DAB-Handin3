using DAB_Handin3.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Handin3.Services
{
    public class MaintenanceLogService
    {
        DataAccess db;

        private const string MaintenanceLogCollection = "Acticity";
        private IMongoCollection<MaintenanceLog> Collection;

        public MaintenanceLogService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<MaintenanceLog>(MaintenanceLogCollection);
        }
    }
}
