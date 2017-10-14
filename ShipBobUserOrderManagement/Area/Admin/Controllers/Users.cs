using Microsoft.AspNetCore.Mvc;
using ShipBobUserOrderManagement.Services.Infrastructures;
using ShipBobUserOrderManagement.ViewModels;
using ShipBobUserOrderManagement.Models;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipBobUserOrderManagement.Area.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]

    public class Users : Controller
    {

        private readonly IUser _userRepository;

        private readonly IOrder _orderRepository;


        public Users(IUser userRepository, IOrder orderRepository)
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
        public JsonResult Create([FromBody]ViewUser theViewUser)
        {
            User theUser = new User();
            theUser.FirstName = theViewUser.FirstName;
            theUser.LastName = theViewUser.LastName;
            return Json(_userRepository.Insert(theUser));
            
            //return View();
        }

        public void Update([FromBody] ViewUser theViewUser)
        {
            User theUser = new User();
            theUser.Id = theViewUser.id;
            theUser.FirstName = theViewUser.FirstName;
            theUser.LastName = theViewUser.LastName;
            _userRepository.Update(theUser);
            _userRepository.Save();

            //return View();
        }


        public JsonResult Delete(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
           return Json(_userRepository.GetAll());
        }

        public JsonResult GetAll()
        {

            var allUser = _userRepository.GetAll();
            return Json(allUser);
        }


        

    }
}
