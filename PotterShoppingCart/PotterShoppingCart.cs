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
            var orderGroupList = new List<List<int>>();

            // 把資料分成不重複的一組
            foreach (var order in orders)
            {
                for (int i = 0; i < order.Amount; i++)
                {
                    if (orderGroupList.Count <= i)
                    {
                        var ordergroup = new List<int>();
                        ordergroup.Add(order.Volumn);
                        orderGroupList.Add(ordergroup);
                    }
                    else
                    {
                        orderGroupList[i].Add(order.Volumn);
                    }
                }
            }

            // 尋訪所有組別後依個別折扣計算總價
            foreach (var ordergroup in orderGroupList)
            {
                switch (ordergroup.Count)
                 case 1: // 原價

                    totalPrice += ordergroup.Count * _bookOrigionPrice;
                    break;

                case 2: // 2本95折

                    totalPrice += (int)(ordergroup.Count * _bookOrigionPrice * 0.95);
                    break;

                case 3: // 3本9折

                    totalPrice += (int)(ordergroup.Count * _bookOrigionPrice * 0.9);
                    break;

                case 4: // 4本8折

                    totalPrice += (int)(ordergroup.Count * _bookOrigionPrice * 0.8);
                    break;

                case 5: // 5本75折

                    totalPrice += (int)(ordergroup.Count * _bookOrigionPrice * 0.75);
                    break;

                default:
                    throw new Exception("This order is illegal (unknown book?)");                    
                }
            }

            return totalPrice;
        }
    }
}