using ShipBobUserOrderManagement.Services.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShipBobUserOrderManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ShipBobUserOrderManagement.Services.Repository
{
    public class OrderRepository : IOrder
    {

        private readonly Models.AppContext _db;

        public OrderRepository(Models.AppContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Orders.Count();
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }

        public IEnumerable<Order> GetAll()
        {

             return _db.Orders.Select(o => o);
            //return _db.Orders.Include(u => u.User).Select(o => o);
        }

        public IEnumerable<Order> GetAllOrdersAssociatedWithUser(int id)
        {
            return _db.Orders.Where(o => o.UserId == id);
        }

        public Order GetById(int id)
        {
            return _db.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void Insert(Order order)
        {
             _db.Orders.Add(order);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Order order)
        {
            _db.Orders.Update(order);
        }
    }
}
