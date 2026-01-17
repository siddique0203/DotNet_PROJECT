using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReportRepo : IReportFeature
    {
        SSMSContext db;
        public ReportRepo(SSMSContext db)
        {
            this.db = db;
        }

        // Total bookings per month
        public List<object> TotalBookingsPerMonth()
        {
            return db.Bookings
                .GroupBy(b => new { b.ShiftDate.Year, b.ShiftDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    TotalBookings = g.Count()
                }).ToList<object>();
        }

        // Total revenue
        public double TotalRevenue()
        {
            return db.Payments
                     .Where(p => p.PaymentStatus == "Paid")
                     .Sum(p => p.Amount);
        }

        // Monthly revenue
        public List<object> MonthlyRevenue()
        {
            return db.Payments
                .Where(p => p.PaymentStatus == "Paid")
                .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Revenue = g.Sum(x => x.Amount)
                }).ToList<object>();
        }

        // Daily income report
        public List<object> DailyIncome()
        {
            return db.Payments
                .Where(p => p.PaymentStatus == "Paid")
                .GroupBy(p => p.PaymentDate.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Amount = g.Sum(x => x.Amount)
                }).ToList<object>();
        }

        // Most booked route
        public object MostBookedRoute()
        {
            return db.Bookings
                .GroupBy(b => new { b.FromAddress, b.ToAddress })
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    g.Key.FromAddress,
                    g.Key.ToAddress,
                    TotalBookings = g.Count()
                })
                .FirstOrDefault();
        }

        // Agency ratings
        public List<object> AgencyRatings()
        {
            // Step 1: Get all agencies
            var agencies = db.Users.Where(u => u.UserType == "Agency").ToList();

            var result = agencies.Select(a =>
            {
                // Step 2: Get feedbacks for this agency
                var feedbacks = db.Feedbacks
                                  .Where(f => f.Booking.UserID == a.UserID)
                                  .Select(f => f.RatingValue)
                                  .ToList(); // <-- bring to memory

                return new
                {
                    AgencyID = a.UserID,
                    AgencyName = a.FullName,
                    TotalReviews = feedbacks.Count,
                    AverageRating = feedbacks.Any() ? feedbacks.Average() : 0
                };
            }).ToList<object>();

            return result;
        }
    }
}
