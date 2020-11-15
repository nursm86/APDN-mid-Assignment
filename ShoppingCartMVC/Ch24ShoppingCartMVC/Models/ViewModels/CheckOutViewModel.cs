using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPriceEachItem { get; set; }
    }
}