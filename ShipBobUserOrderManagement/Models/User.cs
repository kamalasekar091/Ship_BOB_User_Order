using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipBobUserOrderManagement.Models
{
    [Table("user")]
    public class User: EntityBase
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }


        [Required, Display(Name = "First Name"), StringLength(25)]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name"), StringLength(25)]
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
