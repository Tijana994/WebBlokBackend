﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Address { get; set; }
        [Required]
        [ForeignKey("Servis")]
        public int ServisId { get; set; }
        public Servis Servis { get; set; }
        public List<Reservation> ReceptionReservations { get; set; }
        public List<Reservation> ReturnReservations { get; set; }
    }
}