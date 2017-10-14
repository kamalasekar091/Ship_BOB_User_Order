using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipBobUserOrderManagement.Services.Infrastructures;
using ShipBobUserOrderManagement.ViewModels;
using ShipBobUserOrderManagement.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipBobUserOrderManagement.Area.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class Orders : Controller
    {

        private readonly IUser _userRepository;

        private readonly IOrder _orderRepository;


        public Orders(IUser userRepository, IOrder orderRepository)
        {

            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create([FromBody] ViewOrder theViewUser)
        {
            Order theUser = new Order(theViewUser);

           _orderRepository.Insert(theUser);
            _orderRepository.Save();

            return Json(_orderRepository.GetAll()); ;
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            var allOrders = _orderRepository.GetAll();
            return Json(allOrders);
        }


        [HttpGet("{id}")]
        public JsonResult GetOrderForaUser(int id)
        {

            return Json(_orderRepository.GetAllOrdersAssociatedWithUser(id));
        }

        [HttpPut]
        public JsonResult Update([FromBody] ViewOrder theViewUser)
        {

            Order theUser = new Order(theViewUser);
            _orderRepository.Update(theUser);
            _orderRepository.Save();
            var allOrders = _orderRepository.GetById(theUser.Id);
            return Json(allOrders);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
            return Json(_orderRepository.GetAll());
        }


    }
}
