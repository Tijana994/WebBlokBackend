using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        [MaxLength(400)]
        public string Comment { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public int AppUserId { get; set; } //FK
        public AppUser AppUser { get; set; }

        [Required]
        [ForeignKey("Servis")]
        public int ServisId { get; set; }
        public Servis Servis { get; set; }
    }
}