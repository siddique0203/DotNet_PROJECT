using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FeedbackDTO
    {
        public int FeedbackID { get; set; }
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
