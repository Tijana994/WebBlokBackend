using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class Pic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Path { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        
       
    }
}