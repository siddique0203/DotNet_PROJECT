using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> Get();
        T Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
