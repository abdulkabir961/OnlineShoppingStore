using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities(); 
        public ActionResult Index(string search,int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, 8, page));
        }

        public ActionResult AddToCart(int productId)
        {
            var cart = new List<Item>();
            var product = ctx.Tbl_Product.Find(productId);
            cart.Add(new Item()
            {
                Product = product,
                Quantity = 1
            });
            Session["cart"] = cart;
            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}