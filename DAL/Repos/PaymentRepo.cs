using DAL.EF;
using DAL.EF.Models;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : IRepository<Payment>, IPaymentFeature
    {
        SSMSContext db;

        public PaymentRepo(SSMSContext db)
        {
            this.db = db;
        }

        public bool Create(Payment entity)
        {
            db.Payments.Add(entity);
            return db.SaveChanges() > 0;
        }

        // Get all payments with Booking navigation included
        public List<Payment> Get()
        {
            return db.Payments
                     .Include(p => p.Booking)  // Include Booking navigation
                     .ToList();
        }
        public Payment Get(int id)
        {
            return db.Payments
                     .Include(p => p.Booking)
                     .FirstOrDefault(p => p.PaymentID == id);
        }

        public bool Update(Payment entity)
        {
            db.Payments.Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var p = Get(id);
            if (p == null) return false;
            db.Payments.Remove(p);
            return db.SaveChanges() > 0;
        }

        public Payment GetByBooking(int bookingId)
        {
            return db.Payments.FirstOrDefault(p => p.BookingID == bookingId);
        }
    }
}
