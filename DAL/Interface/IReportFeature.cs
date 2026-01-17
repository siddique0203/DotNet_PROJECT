using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IReportFeature
    {
        List<object> TotalBookingsPerMonth();
        double TotalRevenue();
        List<object> MonthlyRevenue();
        List<object> DailyIncome();
        object MostBookedRoute();
        List<object> AgencyRatings();
    }
}
