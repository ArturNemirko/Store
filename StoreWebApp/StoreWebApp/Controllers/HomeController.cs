using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDB.DAL;
using StoreDB.Entities;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.Title = "Stores";
            var list = unitOfWork.Stores.GetAll().ToList();
            var slist = new SelectList(list, "Id", "Name", list.First());
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

        public ActionResult StoreSettings()
        {
            ViewBag.Title = "Store Settings";
            return View(unitOfWork.Stores.GetAll().ToList());
        }

        public ActionResult DeleteStore(int id)
        {
            unitOfWork.Stores.Delete(id);
            unitOfWork.Save();
            return Redirect("StoreSettings");
        }

        public ActionResult CreateStore(string storeName, string storeAddress, string time)
        {
            Store store = new Store() {Name = storeName, Address = storeAddress, Products = new List<Product>()};
            unitOfWork.Stores.Create(store);
            unitOfWork.Save();
            return Redirect("StoreSettings");
        }


    }
}
