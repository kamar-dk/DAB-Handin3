using System;
using System.Collections.Generic;
using System.Linq;
using DAB_2_Solution_grp5.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;



namespace DAB_2_Solution_grp5.Data
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1, 1433; Database=DAB2_1; User ID=sa;Password=<YourStrong@Passw0rd> ;TrustServerCertificate=true; ApplicationIntent=ReadWrite;");
        }

        public DbSet<Facility>? Facilities { get; set; }
        public DbSet<Citizen>? Citizens { get; set; }
        public DbSet<Activity>? Activities { get; set; }
        public DbSet<Personnel>? Personnels { get; set; }
        public DbSet<MaintenanceLog>? MaintenanceLogs { get; set; }
        public DbSet<Participant>? Participants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Citizen
            modelBuilder.Entity<Citizen>().HasKey(a => a.CitizenId);
            modelBuilder.Entity<Citizen>().HasData(
                 new Citizen { CitizenId = 1, Namee = "Clara", Email = "Clara@gmail.com", CVR = "12103023031", Category = "Business", PhoneNumber = "25252525" },
                 new Citizen { CitizenId = 2, Namee = "Rasmus", Email = "Rasmus@gmail.com", CVR = "109876543", Category = "Forretning", PhoneNumber = "42345677" },
                 new Citizen { CitizenId = 3, Namee = "Heja", Email = "Heja@gmail.com", CVR = "098765432", Category = "Forretning", PhoneNumber = "42336789" });


            // Personnel
            modelBuilder.Entity<Personnel>().HasKey(b => b.PersId);
            modelBuilder.Entity<Personnel>().HasData(
                 new Personnel { PersId = 1 },
                 new Personnel { PersId = 2 });

            // Facility
            modelBuilder.Entity<Facility>().HasKey(b => b.FacilityId);
            modelBuilder.Entity<Facility>().HasData(
                new Facility { FacilityId = 1, Name = "AarhusStrand", Longitude = 41.40338, Latitude = 2.17403, Type = "Privat", Description = "God plads", /*Bookable = "Ja", Items = "offentlig toillet"*/},
                new Facility { FacilityId = 2, Name = "Navitas", Longitude = 32.3445, Latitude = 34.5566, Type = "Forretning", Description = "Den ligger ved haven kanten" /*Bookable = "Ja", //Items = "Bord og stoler"*/},
                new Facility { FacilityId = 3, Name = "Aarhus Universitet", Longitude = 23.44556, Latitude = 1.23334, Type = "Forretning", Description = "Skole" /*Bookable = "Ja",//Items = "Bord og stoler"*/ },
                new Facility { FacilityId = 4, Name = "Storcenter Nord", Longitude = 12.33343, Latitude = 98.66777, Type = "Shopping", Description = "Ligger i aarhus N" /*//Bookable = "Ja",  //Items = "Butikker"*/});

            // Activity
            modelBuilder.Entity<Activity>().HasKey(b => b.ActivityId);
            modelBuilder.Entity<Activity>().HasData(
                 new Activity { ActivityId = 1, StartTime = new DateTime(2022, 3, 2, 12, 30, 1), EndTime = new DateTime(2022, 3, 2, 12, 30, 1), Note = "jnjcxdzrtfyguhijokpszxrtfgyhuijokl", CitizenId = 3,FacilityId = 4 },
                 new Activity { ActivityId = 2, StartTime = new DateTime(2022, 3, 2, 12, 30, 1), EndTime = new DateTime(2022, 3, 2, 12, 30, 1), Note = "jnjcxdzrtfyguhijokpszxrtfgyhuijokl", CitizenId = 1, FacilityId = 2 });

            modelBuilder.Entity<Activity>()
                .HasOne(ba => ba.Citizen)
                .WithMany(b => b.Activities)
                .HasForeignKey(ba => ba.CitizenId);

            modelBuilder.Entity<Activity>()
                .HasOne(ba => ba.Facility)
                .WithMany(a => a.Activities)
                .HasForeignKey(ba => ba.FacilityId);

            // MaintenanceLog
            modelBuilder.Entity<MaintenanceLog>().HasKey(b => b.MaintenanceId);
            modelBuilder.Entity<MaintenanceLog>().HasData(
                new MaintenanceLog { MaintenanceId = 1, Description = "reparede en stol", Date = new DateTime(2022,3,2,12,30,1), FacilityId = 1, PersId = 1 },
                new MaintenanceLog { MaintenanceId = 2, Description = "skiftede pære", Date = new DateTime(2022, 2, 1, 12, 00, 20), FacilityId = 2, PersId = 2 },
                new MaintenanceLog { MaintenanceId = 3, Description = "Rengjort toilletter", Date = new DateTime(2021, 5, 14, 15, 30, 30), FacilityId = 1, PersId = 2 });
            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(ba => ba.Personnel)
                .WithMany(a => a.MaintenanceLogs)
                .HasForeignKey(ba => ba.PersId);

            modelBuilder.Entity<MaintenanceLog>()
                .HasOne(ba => ba.Facility)
                .WithMany(a => a.MaintenanceLogs)
                .HasForeignKey(ba => ba.FacilityId);

            // Participant
            modelBuilder.Entity<Participant>().HasKey(b => b.ParticipantId);
            modelBuilder.Entity<Participant>().HasData(
                new Participant { ParticipantId = 1, Cpr = "123021-1234", ActivityId = 1 },
                new Participant { ParticipantId = 2, Cpr = "123021-2345", ActivityId = 1 },
                new Participant { ParticipantId = 3, Cpr = "123021-3456", ActivityId = 2 });
        }

    }
}