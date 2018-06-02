using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACarApp.Models
{
    public class BranchReservation
    {
        public class MemberComment
        {
            [Key, Column(Order = 0)]
            public int BranchID { get; set; }
            [Key, Column(Order = 1)]
            public int ReservationID { get; set; }

            public virtual Reservation Reservation { get; set; }
            public virtual Branch Branch { get; set; }

            public bool Reception { get; set; }
            
        }
    }
}