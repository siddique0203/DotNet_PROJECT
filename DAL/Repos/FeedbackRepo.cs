using DAL.EF;
using DAL.EF.Models.DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    internal class FeedbackRepo : IRepository<Feedback>
    {
        private readonly SSMSContext db;

        public FeedbackRepo(SSMSContext db)
        {
            this.db = db;
        }

        public List<Feedback> Get()
        {
            return db.Feedbacks
                     .Include(f => f.User)
                     .Include(f => f.Booking)
                     .ToList();
        }

        public Feedback Get(int id)
        {
            return db.Feedbacks
                     .Include(f => f.User)
                     .Include(f => f.Booking)
                     .FirstOrDefault(f => f.FeedbackID == id);
        }

        public bool Create(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(Feedback entity)
        {
            db.Feedbacks.Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var feedback = Get(id);
            if (feedback == null) return false;

            db.Feedbacks.Remove(feedback);
            return db.SaveChanges() > 0;
        }
    }
}
