using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_2_Solution_grp5.Models
{
    public class Personnel
    {
        
        public int PersId { get; set; }


        
        public List<MaintenanceLog> MaintenanceLogs { get; set; } 
    }
}
