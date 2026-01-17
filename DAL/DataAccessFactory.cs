using DAL.EF;
using DAL.EF.Models;
using DAL.EF.Models.DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        SSMSContext db;

        public DataAccessFactory(SSMSContext db)
        {
            this.db = db;
        }

        
        public IRepository<User> UserData()
        {
            return new UserRepo(db);
        }

        public IRepository<Booking> BookingData()
        {
            return new BookingRepo(db);
        }

        public IRepository<Payment> PaymentData()
        {
            return new PaymentRepo(db);
        }

        public IPaymentFeature PaymentFeature()
        {
            return new PaymentRepo(db);
        }

       
        public IRepository<Feedback> FeedbackData()
        {
            return new FeedbackRepo(db);
        }

        public IReportFeature ReportFeature()
        {
            return new ReportRepo(db);
        }

    }
}
