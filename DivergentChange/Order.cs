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

        public List<OrderItem> Items => _items;
    }

    public class OrderItem
    {
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }

