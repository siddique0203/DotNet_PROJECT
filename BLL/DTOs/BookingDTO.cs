using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime ShiftDate { get; set; }
        public string Status { get; set; }
        public string InventoryDetails { get; set; }
        public int UserID { get; set; }
    }
}
