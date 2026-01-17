using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        DataAccessFactory factory;
        private object repo;

        public ReportService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public object TotalBookingsPerMonth() => factory.ReportFeature().TotalBookingsPerMonth();
        public double TotalRevenue() => factory.ReportFeature().TotalRevenue();
        public object MonthlyRevenue() => factory.ReportFeature().MonthlyRevenue();
        public object DailyIncome() => factory.ReportFeature().DailyIncome();
        public object MostBookedRoute() => factory.ReportFeature().MostBookedRoute();
        public object AgencyRatings() => factory.ReportFeature().AgencyRatings();
    }
}
