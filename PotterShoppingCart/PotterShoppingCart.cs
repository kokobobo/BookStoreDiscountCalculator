using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart
{
    public class Order
    {
        public int Volumn { get; set; }
        public int Amount { get; set; }      
    }

    public class PotterShoppingCart
    {
        public PotterShoppingCart()
        {
        }
        public int CountShippingCart(IEnumerable<Order> orders)
        {
            var totalprice = 0;
            foreach (var order in orders)
            {
                totalprice += order.Amount * 100;
            }
            return totalprice;
        }
    }
}
