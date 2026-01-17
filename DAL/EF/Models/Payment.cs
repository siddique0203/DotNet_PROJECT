using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public double Amount { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string PaymentMethod { get; set; } // Cash, Bkash, Card

        [Column(TypeName = "VARCHAR(50)")]
        public string PaymentStatus { get; set; } // Pending, Paid

        public DateTime PaymentDate { get; set; }

        // FK
        public int BookingID { get; set; }

        // Navigation
        public virtual Booking Booking { get; set; }
    }

}
