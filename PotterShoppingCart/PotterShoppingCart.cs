using System;
using System.Collections.Generic;

namespace PotterShoppingCart
{
    public class OrderData
    {
        public int Volumn { get; set; }
        public int Amount { get; set; }
    }

    public class PotterShoppingCart
    {
        static private int _bookOrigionPrice = 100;

        public PotterShoppingCart()
        {
        }

        public int CountShippingCart(IEnumerable<OrderData> orders)
        {
            var totalPrice = 0;
            var discountAmount = 0;
            var normalAmount = 0;

            foreach (var order in orders)
            {
                if (normalAmount == 0)
                {
                    normalAmount = order.Amount;
                }
                else
                {
                    discountAmount = Math.Min(normalAmount, order.Amount);
                    normalAmount -= discountAmount;
                }
            }

            totalPrice = (int)(discountAmount * 2 * _bookOrigionPrice * 0.95);
            totalPrice += normalAmount * _bookOrigionPrice;
 
            return totalPrice;
        }
    }
}