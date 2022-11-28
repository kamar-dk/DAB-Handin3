using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_2_Solution_grp5.Models
{
    public class MaintenanceLog
    {
        
        public int MaintenanceId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; } 

        

        public int PersId { get; set; }
        public Personnel Personnel { get; set; } 

    }
}
