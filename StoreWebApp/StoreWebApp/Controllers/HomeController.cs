using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDB.Service;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceStore _service = new ServiceStore();
        public ActionResult Index()
        {
            ViewBag.Title = "Stores";
            //var list = _service.GetAllStores().ToList();
            return View(_service.GetAllStores().ToList());
        }

        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            return View();
        }

        public ActionResult ShowProducts(int? id)
        {
            if(id!=null)
                return View("Products", _service.GetProductsStore((int)id).ToList());
            return View("Index");
        }
    }
}
