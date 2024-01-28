using Strategy_Pattern_Using_different_shipping_providers.Business.Models;
using System;
using System.Collections.Generic;

namespace Strategy_Pattern_Using_different_shipping_providers
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new[] {
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Singapore"
                    }
                }
            };

            Print(orders);

            Console.WriteLine();
            Console.WriteLine("Sorting..");
            Console.WriteLine();

            /// TODO: Sort array with strategies implementing IComparer<T>

            Array.Sort(orders, new OrderAmountComparer());
            Console.WriteLine("Sorted based on order amount");
            Console.WriteLine();
            Print(orders);
            Console.WriteLine();
            Array.Sort(orders, new OrderOriginComparer());
            Console.WriteLine("Sorted based on origin");
            Console.WriteLine();
            Print(orders);
        }

        static void Print(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order.ShippingDetails.OriginCountry);
            }
        }
    }

    #region Strategies
    /// <summary>
    /// Sorts order based on Amount
    /// </summary>
    public class OrderAmountComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            var xTotal = x.TotalPrice;
            var yTotal = y.TotalPrice;
            if (xTotal == yTotal)
            {
                return 0;
            }
            else if (xTotal > yTotal)
            {
                return 1;
            }

            return -1;
        }
    }

    /// <summary>
    /// Sorts orders based on Country of Origin
    /// </summary>
    public class OrderOriginComparer : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            var xDest = x.ShippingDetails.OriginCountry.ToLowerInvariant();
            var yDest = y.ShippingDetails.OriginCountry.ToLowerInvariant();
            if (xDest == yDest)
            {
                return 0;
            }
            else if(xDest[0] > yDest[0])
            {
                return 1;
            }

            return -1;
        }
    }
    #endregion
}
