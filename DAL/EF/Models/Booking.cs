using DAL.EF.Models.DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string FromAddress { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string ToAddress { get; set; }

        public DateTime ShiftDate { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Status { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string InventoryDetails { get; set; }

        // Foreign Key
        [ForeignKey("User")]
        public int UserID { get; set; }


        // Navigation
        public virtual User User { get; set; }
        public virtual Feedback Feedback { get; set; }
        public virtual Payment Payment { get; set; }

    }
}
