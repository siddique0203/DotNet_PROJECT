using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }   // Cash, Bkash, Card
        public string PaymentStatus { get; set; }   // Pending, Paid
        public DateTime PaymentDate { get; set; }
        public int BookingID { get; set; }
    }
}
