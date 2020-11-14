using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Models{
    public class CartModel
    {
        //Data Access methods 
        private List<ProductViewModel> GetCartFromDataStore()
        {
            List<ProductViewModel> cart;
            object objCart = HttpContext.Current.Session["cart"];
            //Convert objCart to List<ProductViewModel>
            cart = objCart as List<ProductViewModel>;
            if (cart == null)
            {   //Create the object cart
                cart = new List<ProductViewModel>();//doubttttttttttttt
                //Assign cart to the Session object cart
                HttpContext.Current.Session["cart"] = cart;
            }
            return cart;
        }
        private ProductViewModel GetSelectedProduct(string id)
        {   //Create an OrderModel object called order
            OrderModel order = new OrderModel();
            //Call the method GetSelectedProduct of the class OrderModel. Return the object returned by the call.
            return order.GetSelectedProduct(id);
        }
        public CartViewModel GetCart(string id = "")
        {
            CartViewModel model = new CartViewModel();
            //Call the method GetCartFromDataStore
            model.Cart = GetCartFromDataStore();
            if (!string.IsNullOrEmpty(id))
                //Called the method GetSelectedProduct with parameter id and assign the return object to the AddedProduct
                model.AddedProduct = GetSelectedProduct(id);
            return model;
        }
        private void AddItemToDataStore(CartViewModel model)
        {   //Add the AddedProduct to the cart
            
        }
        public void AddToCart(CartViewModel model)
        {
            if (model.AddedProduct.ProductID != null)
            {
                //Get the product id of the added product
                string id = model.AddedProduct.ProductID;
                //Find the product in the cart that matches the id using lambda expression.
                ProductViewModel inCart = model.Cart.Where(x => x.ProductID == id).FirstOrDefault();
                if (inCart == null)
                    AddItemToDataStore(model);                    //Call the method AddItemToDataStore
                else
                    model.AddedProduct.Quantity += model.AddedProduct.Quantity;
                    //Increase the Quantity by the quantity of the added product
                    
            }
        }
                
       
    }    
}