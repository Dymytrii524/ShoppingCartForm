using System;
using System.Collections.Generic;

namespace Computer_Parts_Store.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int GetTotalItemsCount()
        {
            int count = 0;
            foreach (var item in Items)
            {
                count += item.Quantity;
            }
            return count;
        }

        public void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Product.Price * item.Quantity;
            }
            TotalAmount = total;
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            PriceAtPurchase = product.Price;
        }
    }
}
