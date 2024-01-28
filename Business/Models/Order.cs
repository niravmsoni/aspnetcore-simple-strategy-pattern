using System.Collections.Generic;
using System.Linq;

namespace Strategy_Pattern_Using_different_shipping_providers.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingDetails ShippingDetails { get; set; }

    }
    public class ShippingDetails
    {
        public string Receiver { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string DestinationCountry { get; set; }
        public string DestinationState { get; set; }

        public string OriginCountry { get; set; }
        public string OriginState { get; set; }
    }

    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public ItemType ItemType { get; set; }

        //public decimal GetTax()
        //{
        //    switch (ItemType)
        //    {
        //        case ItemType.Service:
        //        case ItemType.Food:
        //        case ItemType.Hardware:
        //        case ItemType.Literature:
        //        default:
        //            return 0m;
        //    }
        //}

        public Item(string id, string name, decimal price, ItemType type)
        {
            Id = id;
            Name = name;
            Price = price;
            ItemType = type;
        }
    }

    public enum ItemType
    {
        Service,
        Food,
        Hardware,
        Literature
    }
}