using ShipBobUserOrderManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShipBobUserOrderManagement.Models
{
    [Table("order")]
    public class Order: EntityBase
    {
        public Order(ViewOrder theViewOrder)
        {
            UserId = theViewOrder.UserId;
            Id = theViewOrder.OrderId;
            Name = theViewOrder.Name;
            TrackingID = theViewOrder.TrackingID;
            StreetAddress = theViewOrder.StreetAddress;
            City = theViewOrder.City;
            State = theViewOrder.State;
            ZipCode = theViewOrder.ZipCode;
        }

        public Order()
        {

        }

        [Required, Display(Name = "User Id")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required, Display(Name = "Delivery Name"), StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tracking Id is Required !"), Display(Name = "Tracking ID")]
        public string TrackingID { get; set; }
        [Required, Display(Name = "Street Address"), StringLength(100)]
        public string StreetAddress { get; set; }
        [Required, Display(Name = "City"), StringLength(10)]
        public string City { get; set; }
        [Required, Display(Name = "State"), StringLength(2)]
        public string State { get; set; }
        [Required, Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }
    }
}
