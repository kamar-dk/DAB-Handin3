using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_2_Solution_grp5.Models
{
    public class Citizen
    {
        
        public int CitizenId { get; set; }
        public string Namee { get; set; }
        public string Email { get; set; }
        public string CVR { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }


        public List<Activity> Activities { get; set; }

    }
}
