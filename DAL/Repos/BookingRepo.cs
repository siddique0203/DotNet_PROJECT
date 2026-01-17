using DAL.EF;
using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    internal class BookingRepo : IRepository<Booking>
    {
        private readonly SSMSContext db;

        public BookingRepo(SSMSContext db)
        {
            this.db = db;
        }

        public List<Booking> Get()
        {
            return db.Bookings
                     .Include(b => b.User)
                     .Include(b => b.Feedback)
                     .ToList();
        }

        public Booking Get(int id)
        {
            return db.Bookings
                     .Include(b => b.User)
                     .Include(b => b.Feedback)
                     .FirstOrDefault(b => b.BookingID == id);
        }
        // Get payment by BookingID
        public Payment GetByBooking(int bookingId)
        {
            return db.Payments
                     .Include(p => p.Booking)
                     .FirstOrDefault(p => p.BookingID == bookingId);
        }
        public bool Create(Booking entity)
        {
            db.Bookings.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(Booking entity)
        {
            db.Bookings.Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var booking = Get(id);
            if (booking == null) return false;

            db.Bookings.Remove(booking);
            return db.SaveChanges() > 0;
        }
    }
}
