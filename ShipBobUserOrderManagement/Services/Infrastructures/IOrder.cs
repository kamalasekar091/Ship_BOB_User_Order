using ShipBobUserOrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobUserOrderManagement.Services.Infrastructures
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAllOrdersAssociatedWithUser(int id);

        Order GetById(int id);

        void Insert(Order order);

        void Update(Order order);

        void Delete(int id);

        int Count();

        void Save();
    }
}
