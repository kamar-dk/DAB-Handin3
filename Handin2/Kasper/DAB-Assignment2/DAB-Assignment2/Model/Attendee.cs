﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAB_Assignment2.Model
{
    public class Attendee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cprNr { get; set; }
        public List<Bookings> Bookings { get; set; } = new();
    }
}
