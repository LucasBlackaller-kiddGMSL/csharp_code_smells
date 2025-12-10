namespace DivergentChange;

using System.Collections.Generic;
using System.Linq;

    public class Order
    {
        public void AddItem(decimal price, int quantity)
        {
            Items.Add(new OrderItem { Price = price, Quantity = quantity });
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        public List<OrderItem> Items { get; } = new();
    }