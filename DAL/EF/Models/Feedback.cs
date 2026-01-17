using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DAL.EF.Models
    {
        public class Feedback
        {
            public int FeedbackID { get; set; }

            public int RatingValue { get; set; }

            [Column(TypeName = "VARCHAR(200)")]
            public string Comment { get; set; }

            public DateTime CreatedDate { get; set; }

            // Foreign Keys
            [ForeignKey("Booking")]
            public int BookingID { get; set; }

            [ForeignKey("User")]
            public int UserID { get; set; }

            // Navigation
            public virtual Booking Booking { get; set; }
            public virtual User User { get; set; }
        }
    }

}
