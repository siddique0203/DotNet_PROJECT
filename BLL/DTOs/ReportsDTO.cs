using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MonthlyBookingDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalBookings { get; set; }
    }

    public class RevenueDTO
    {
        public double TotalRevenue { get; set; }
    }

    public class DailyIncomeDTO
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }

    public class MonthlyRevenueDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public double Revenue { get; set; }
    }

    public class PopularRouteDTO
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int TotalBookings { get; set; }
    }

    public class AgencyRatingDTO
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
    }
}
