using DAL.EF;
using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos
{
    internal class UserRepo : IRepository<User>
    {
        private readonly SSMSContext db;

        public UserRepo(SSMSContext db)
        {
            this.db = db;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Create(User entity)
        {
            db.Users.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(User entity)
        {
            db.Users.Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            if (user == null) return false;

            db.Users.Remove(user);
            return db.SaveChanges() > 0;
        }
    }
}
