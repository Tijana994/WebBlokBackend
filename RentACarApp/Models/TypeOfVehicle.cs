using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class TypeOfVehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name{ get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}