using RentACarApp.Dependency_Injection;
using RentACarApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var unitofwork = new Dependency().Unit)
            {
                
                foreach (var item in unitofwork.AppUsers.GetAll())
                {
                    Console.WriteLine(item.Name);
                }
            }

            return View();
        }
    }
}
