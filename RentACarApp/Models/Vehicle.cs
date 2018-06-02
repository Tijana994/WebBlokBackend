using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Mark { get; set; }
        [Required]
        [MaxLength(40)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(40)]
        public string Description { get; set; }

        [Required]
        public bool Aveliable;

        [Required]
        [ForeignKey("TypeOfVehicle")]
        public int TypeOfVehicleId { get; set; }
        public TypeOfVehicle TypeOfVehicle { get; set; }  //FK

        public List<Pic> Pics { get; set; }   //format jedne slike : idVozila_nazivSlike

        [Required]
        [ForeignKey("Servis")]
        public int ServisId { get; set; }
        public Servis Servis { get; set; }

        public virtual ICollection<PriceList> PriceLists { get; set; }
    }
}