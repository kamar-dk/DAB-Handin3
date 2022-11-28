using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using DAB_2_Solution_grp5.Data;
using DAB_2_Solution_grp5.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Net.Sockets;

namespace DAB_2_Solution_grp5.Data
{
    class Program
    {
        static void Main()
        {
            MyDbContext db = new MyDbContext();

            {
                Console.WriteLine("Start");

                while (true)
                {

                    Console.WriteLine("\n" + "Vis Opgave2_1(a) Opgave2_2(b), Opgave2_3(c), Opgave3_2(d), Opgave3_3(e)");
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    if (consoleKeyInfo.KeyChar == 'a' || consoleKeyInfo.KeyChar == 'b' || consoleKeyInfo.KeyChar == 'c' || consoleKeyInfo.KeyChar == 'd' || consoleKeyInfo.KeyChar == 'e')
                    {
                        VaelgOpgave(db, consoleKeyInfo.KeyChar);
                    }

                    else
                    {
                        return;
                    }
                }
                
            }
        }

        static void VaelgOpgave(MyDbContext db, char c)
        {
            switch (c)
            {
                case 'a':
                    Opgave2_1(db);
                    break;

                case 'b':
                    Opgave2_2(db);
                    break;

                case 'c':
                    Opgave2_3(db);
                    break;
                case 'd':
                    Opgave3_2(db);
                    break;
                case 'e':
                    Opgave3_3(db);
                    break;
            }
        }

        static void Opgave2_1(MyDbContext db)
        {
            foreach (var fac in db.Facilities)
            {
                Console.WriteLine(fac.Name + " har addressen" + fac.Longitude + ", " + fac.Latitude);
            }
        }

        static void Opgave2_2(MyDbContext db)
        {
            var ListOfFacilitiesSorted = db.Facilities.OrderBy(x => x.Type);
            Console.WriteLine("\nListe af Faciliteter \n");
            foreach (var fac in ListOfFacilitiesSorted)
            {

                Console.WriteLine(fac.Name + " " + fac.Longitude + ", " + fac.Latitude + " " + fac.Type);
            }
        }

        static void Opgave2_3(MyDbContext db)
        {

            var alist = db.Activities.ToList();
            foreach (var activity in alist)
            {
                Console.WriteLine(
                    $"\n {db.Facilities.First(u => u.FacilityId == activity.FacilityId).Name} | " +
                    $"{db.Citizens.First(u => u.CitizenId == activity.CitizenId).Namee} | " +
                    $"{db.Activities.First(u => u.ActivityId == activity.ActivityId).StartTime} - " +
                    $"{db.Activities.First(u => u.ActivityId == activity.ActivityId).EndTime}");
            }


        }

        static void Opgave3_2(MyDbContext db)
        {
            var alist = db.Activities.Include(a => a.Participants);

            foreach (var a in alist)
            {


                Console.WriteLine(a.ActivityId);
                var temp = a.Participants;

                foreach (var act in temp)
                {
                    Console.WriteLine(act.Cpr);
                }
            }

        }
        static void Opgave3_3(MyDbContext db)
        {

            var blist = db.MaintenanceLogs.ToList();
            var blist1 = blist.OrderBy(s => s.FacilityId);
            foreach (var maintenance in blist1)
            {
                Console.WriteLine(
                    $"\n{db.Facilities.First(u => u.FacilityId == maintenance.FacilityId).Name}| " +
                    $"{db.Personnels.First(u => u.PersId == maintenance.PersId).PersId}| " +
                    $"{db.MaintenanceLogs.First(u => u.MaintenanceId == maintenance.MaintenanceId).Date} | " +
                    $"{db.MaintenanceLogs.First(u => u.MaintenanceId == maintenance.MaintenanceId).Description}");
            }
        }
    }
}


