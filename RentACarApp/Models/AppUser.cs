using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Approved { get; set; }
        [Required]
        public bool LoggedIn { get; set; }
        [Required]
        public bool CreateService { get; set; }
        [MaxLength(200)]
        public string Path { get; set; } //format : idKorisnika_Dokument

        public virtual ICollection<Rate> Rates { get; set; } //FK-s
        public virtual ICollection<Reservation> Reservations { get; set; } //FK-s
    }
}