using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart
{
    public class OrderData
    {
        public int Volumn { get; set; }
        public int Amount { get; set; }      
    }

    public class PotterShoppingCart
    {
        public PotterShoppingCart()
        {
        }
        public int CountShippingCart(IEnumerable<OrderData> orders)
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
