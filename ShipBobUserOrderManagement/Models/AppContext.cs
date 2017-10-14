using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobUserOrderManagement.Models
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext>options):base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
