using ShipBobUserOrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobUserOrderManagement.ViewModels
{
    public class ViewOrder
    {

        public int OrderId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
        
        public string Name { get; set; }
        
        public string TrackingID { get; set; }
        
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        
        public int ZipCode { get; set; }
    }
}
