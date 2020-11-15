using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckOutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CartViewModel model = Session["cart"] as CartViewModel;
            //if the model is null, then call the method GetCart
            if (model == null)
            {
                CartModel cm = new CartModel();
                model = cm.GetCart();
            }
            List<CheckOutViewModel> covm = new List<CheckOutViewModel>();
            foreach(var item in model.Cart)
            {
                CheckOutViewModel c = new CheckOutViewModel()
                {
                    ProductID = item.ProductID,
                    Name = item.Name,
                    Quantity =item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPriceEachItem = item.Quantity * item.UnitPrice
                };
                covm.Add(c);
            }
            return View(covm);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            TempData["paymentMethod"] = fc["paymentMethod"];
            TempData["shippingAddress"] = fc["shippingAddress"];
            return RedirectToAction("Confirmation");
        }
        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
