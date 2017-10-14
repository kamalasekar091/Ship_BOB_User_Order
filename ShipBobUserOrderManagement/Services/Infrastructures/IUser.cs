using ShipBobUserOrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobUserOrderManagement.Services.Infrastructures
{
    public interface IUser
    {
        IEnumerable<User> GetAll();

        IEnumerable<Order> GetAllOrdersAssociatedWithUser(int id);

        User GetById(int id);

        User Insert(User user);

        void Update(User user);

        void Delete(int id);

        int Count();

        void Save();

        
    }
}
