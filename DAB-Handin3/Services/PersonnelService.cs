﻿using DAB_Handin3.Models;
using MongoDB.Driver;

namespace DAB_Handin3.Services
{
    public class PersonnelService
    {
        DataAccess db;

        private const string PersonnelCollection = "Personel";
        private IMongoCollection<Personnel> Collection;

        public PersonnelService(DataAccess db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Personnel>(PersonnelCollection);
        }
        public void CreatePersonel(Personnel personnel)
        {
            Collection.InsertOne(personnel);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(PersonnelCollection);
        }
    }
}
