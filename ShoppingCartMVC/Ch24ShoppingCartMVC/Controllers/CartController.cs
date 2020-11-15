using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
    public class CartController : Controller
    {
        private CartModel cart = new CartModel();

        [HttpGet]
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult List()
        {
            CartViewModel model = Session["cart"] as CartViewModel;
            //if the model is null, then call the method GetCart
            if (model == null)
            {
                CartModel cm = new CartModel();
                model = cm.GetCart();
            }
            //Passing model to View
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult List(OrderViewModel order)
        {
            CartModel cm = new CartModel();
            CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
            //Assign the quantity of the selected product to the quantity of the added product
            model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
            //Call the method AddtoCart
            cm.AddToCart(model);
            //Assign model to the TempData
            TempData["cart"] = model;
            return RedirectToAction("List", "Cart");
        }
       
    }
}
