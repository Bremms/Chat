using ChatApp.Models;
using ChatApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        RoomRepository rooms;
        public HomeController()
        {
            this.rooms = new RoomRepository();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserViewModel());
        }
        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            if (model.Username == null && model.Username == "") //username is empty
                return RedirectToAction("Index");
            HttpCookie cookie = new HttpCookie("UsernameChat"); //persist the username in a cookie
            cookie.Value= model.Username;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Groups");
        }
        public ActionResult Groups()
        {
            return View(rooms.getAllRooms());
        }
        public ActionResult Chat(string groupname)
        {
            HttpCookie cookie = new HttpCookie("GroupNameChat");//persist the groupname in a cookie
            cookie.Value = groupname;
            Response.Cookies.Add(cookie);
            return View();
        }
    }
}