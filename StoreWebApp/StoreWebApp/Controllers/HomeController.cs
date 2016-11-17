using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDB.DAL;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.Title = "Stores";
            return View(unitOfWork.Stores.GetAll().ToList());
        }

        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            return View();
        }

        public ActionResult ShowProducts(int id)
        {
            return View("Products", unitOfWork.Stores.GetElement(id).Products.ToList());
        }
    }
}
