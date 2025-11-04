using System.Collections.Generic;
using System.Linq;
using Computer_Parts_Store.Models;

namespace Computer_Parts_Store.Services
{
    public static class ShoppingCart
    {
        public class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }

        private static List<CartItem> items = new List<CartItem>();

        public static void AddProduct(Product product, int quantity = 1)
        {
            var existingItem = items.FirstOrDefault(i => i.Product.Article == product.Article);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public static List<CartItem> GetItems()
        {
            return items;
        }

        public static void RemoveItem(string article)
        {
            items.RemoveAll(i => i.Product.Article == article);
        }

        public static void Clear()
        {
            items.Clear();
        }

        public static int GetTotalItemsCount()
        {
            return items.Sum(i => i.Quantity);
        }

        public static decimal GetTotalPrice()
        {
            return items.Sum(i => i.Product.Price * i.Quantity);
        }
    }
}
