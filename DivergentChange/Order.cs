namespace DivergentChange;

using System.Collections.Generic;
using System.Linq;

    public class Order
    {
        private readonly List<OrderItem> _items = new List<OrderItem>();

        public void AddItem(decimal price, int quantity)
        {
            _items.Add(new OrderItem { Price = price, Quantity = quantity });
        }

        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        public decimal CalculateShipping(string region, decimal total)
        {
            decimal shipping;

            if (region == "EU")
                shipping = total > 100 ? 0 : 10;
            else if (region == "UK")
                shipping = total > 50 ? 0 : 8;
            else
                shipping = total > 75 ? 0 : 15;

            return shipping;
        }

        public List<OrderItem> Items => _items;
    }

    public class OrderItem
    {
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }

