using ShipBobUserOrderManagement.Services.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShipBobUserOrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ShipBobUserOrderManagement.Services.Repository
{
    public class UserRepository : IUser
    {

        private readonly Models.AppContext _db;

       public UserRepository(Models.AppContext db)
       {
            _db = db;
       }
        public int Count()
        {
            return _db.User.Count();
        }

        public void Delete(int id)
        {
            var user = GetById(id);

            if (user != null)
            {
                _db.User.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _db.User.Select(u => u);
            //return _db.User.Include(o => o.Orders).Select(u => u);
        }

        public IEnumerable<Order> GetAllOrdersAssociatedWithUser(int id)
        {
            return _db.Orders.Where(o => o.UserId == id);
        }

        public User GetById(int id)
        {
            return _db.User.FirstOrDefault(u => u.Id == id);
        }

        public User Insert(User user)
        {
            _db.User.Add(user);
            Save();
            return GetById(user.Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.User.Update(user);
        }
    }
}
